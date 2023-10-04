using BookApp.Application.DTO;
using BookApp.Application.Interface;
using BookApp.Application.Utilities;
using BookApp.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApp.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public UserService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
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
        
    }
}
