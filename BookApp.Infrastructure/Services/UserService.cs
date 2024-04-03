using Microsoft.AspNetCore.Http;

namespace BookApp.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IEncryptService _encryptService;
        private readonly ICloudinaryService _cloudinaryService;
        public UserService(UserManager<ApplicationUser> userManager, IEncryptService encryptService, ICloudinaryService cloudinaryService)
        {
            _userManager = userManager;
            _encryptService = encryptService;
            _cloudinaryService = cloudinaryService;
        }
      

        public async Task<BaseResponse<ChangePasswordDTO>> ChangePassword(ChangePasswordDTO model)
        {
            var user =  await _userManager.FindByIdAsync(model.UserId.ToString());

            if (user == null)
            {
                return new BaseResponse<ChangePasswordDTO>(ResponseMessage.ErrorMessage000);
            }

            var changePassword =  await _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);

            if (!changePassword.Succeeded)
            {
                var errors = new List<string>();
                errors.AddRange(changePassword.Errors.Select(x => x.Description));
                return new BaseResponse<ChangePasswordDTO>(ResponseMessage.PasswordChangedFailure, errors);
            }

            return new BaseResponse<ChangePasswordDTO>(model, ResponseMessage.PasswordChanged);
        }

        public async Task<BaseResponse<string>> ConfirmEmail(string token, string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if(user == null)
            {
                return new BaseResponse<string>(ResponseMessage.ErrorMessage000);
            }

            if(user.EmailConfirmed is true)
            {
                return new BaseResponse<string>(ResponseMessage.AccountAlreadyConfirmed);
            }

            var response = await _userManager.ConfirmEmailAsync(user, _encryptService.Decrypt(token));

            if (!response.Succeeded)
            {
                var errors = new List<string>();
                errors.AddRange(response.Errors.Select(x => x.Description));
                return new BaseResponse<string>(ResponseMessage.ErrorMessage511, errors);
            }

            return new BaseResponse<string>(email, ResponseMessage.AccountConfirmed);
        }


        public async Task<BaseResponse<string>> UpdateProfile(string userId, IFormFile filePath)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if(user == null)
            {
                return new BaseResponse<string>(ResponseMessage.ErrorMessage000);
            }

            var profile = await _cloudinaryService.UploadPicture(filePath);

            user.ProfilePicture = profile;

            var updateProfile = await _userManager.UpdateAsync(user);

            if (updateProfile != null)
            {
                return new BaseResponse<string>(userId, "profile successfully updated");
            }
          
            return new BaseResponse<string>(profile, ResponseMessage.AccountConfirmed);
        }
    }
}
