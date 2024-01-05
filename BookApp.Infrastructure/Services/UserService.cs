namespace BookApp.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IEncryptService _encryptService;
        public UserService(UserManager<ApplicationUser> userManager, IEncryptService encryptService)
        {
            _userManager = userManager;
            _encryptService = encryptService;
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
    }
}
