using BookApp.Application.DTO;
using BookApp.Application.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApp.Application.Interface
{
    public interface IUserService
    {
       
        Task<BaseResponse<ChangePasswordDTO>> ChangePassword(ChangePasswordDTO model);
        /*
        Task<BaseResponse<string>> ConfirmEmail(ConfirmEmailDTO model);
        Task<BaseResponse<ForgotPasswordDTO>> ForgotPassword(ForgotPasswordDTO model);
        Task<BaseResponse<ResetPasswordDTO>> ResetPassword(ResetPasswordDTO model);
        
        */
    }
}
