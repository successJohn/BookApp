using AutoMapper;
using BookApp.Application.DTO;
using BookApp.Application.Interface;
using BookApp.Application.Utilities;
using BookApp.Domain.Entities;
using BookApp.Infrastructure.Persistence;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BookApp.Infrastructure.Services
{
    public class AuthenticationService : IAuthService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;
        public AuthenticationService(ApplicationDbContext context, IMapper mapper, UserManager<ApplicationUser> userManager, IConfiguration configuration)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task<BaseResponse<RegisterDTO>> Register(RegisterDTO model)
        {

            var user = _mapper.Map<ApplicationUser>(model);
            user.RegisteredDate = DateTime.Now;

            var createUserResponse = await _userManager.CreateAsync(user, model.Password);
            if (!createUserResponse.Succeeded)
            {
                var errors = new List<string>();
                errors.AddRange(createUserResponse.Errors.Select(x => x.Description));
                return new BaseResponse<RegisterDTO>(ResponseMessage.AccountCreationFailure, errors);
            }

            return new BaseResponse<RegisterDTO>(model, ResponseMessage.AccountCreationSuccess);
        }

        public async Task<BaseResponse<JwtResponseDTO>> Login(LoginDTO model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);

            if(user == null)
            {
                return new BaseResponse<JwtResponseDTO>(ResponseMessage.ErrorMessage000);
            };
            //TODO: 
            // 1. Check for email Confirmation 
            //2 . check if user is blocked.


            // check for correctness of password

            var correctPassword = await _userManager.CheckPasswordAsync(user, model.Password);

            if (correctPassword)
            {
                var userClaims = await _userManager.GetClaimsAsync(user);
                var userRoles = await _userManager.GetRolesAsync(user);
                var jwtToken = GenerateJwtToken(user, userClaims, userRoles);

                var refreshToken = new RefreshToken
                {
                    Token = BuildRefreshToken(),
                    IssuedAt = DateTime.UtcNow,
                    ExpiresAt = DateTime.UtcNow.AddDays(2),
                    UserId = user.Id
                };


                await _context.RefreshTokens.AddAsync(refreshToken);

                await _context.SaveChangesAsync();

                var result = new JwtResponseDTO
                {
                    Token = jwtToken,
                    RefreshToken = refreshToken.Token
                };

                return new BaseResponse<JwtResponseDTO>(result);
            }
            return new BaseResponse<JwtResponseDTO>(ResponseMessage.ErrorMessage507);
            
        }

        private string GenerateJwtToken(ApplicationUser user, IList<Claim>claims, IList<string>userRoles)
        {

            var jwtTokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(_configuration["JWT:Secret"]);

            var userClaims = BuildJwtClaims(user, claims, userRoles);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(userClaims),
                Issuer = _configuration.GetSection("JWT:ValidIssuer").Value,
                Expires = DateTime.UtcNow.AddMinutes(20),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };

            var token = jwtTokenHandler.CreateToken(tokenDescriptor);

            var jwtToken = jwtTokenHandler.WriteToken(token);

            return jwtToken;        

        }

        private static List<Claim> BuildJwtClaims(ApplicationUser user, IList<Claim> claims, IList<string> userRoles)
        {
            var userClaims = new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, $"{user.FirstName }  {user.LastName}"),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };

            var roleClaim = userRoles.Select(x => new Claim(ClaimTypes.Role, x)).ToList();
            userClaims.AddRange(roleClaim);


            var userClaim = claims.Select(x => new Claim(x.Type, x.Value)).ToList();
            userClaims.AddRange(userClaim);

            return userClaims;
        }

        public string BuildRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var randomNumberGenerator = RandomNumberGenerator.Create())
            {
                randomNumberGenerator.GetBytes(randomNumber);

                return Convert.ToBase64String(randomNumber);
            }
        }


    }
}
