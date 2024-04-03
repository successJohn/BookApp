using BookApp.Application.DTO;
using BookApp.Application.Utilities;
using Microsoft.AspNetCore.Http;
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
        Task<BaseResponse<string>> ConfirmEmail(string token, string email);
        Task<BaseResponse<string>> UpdateProfile(string userId, IFormFile filePath);

    }
}
