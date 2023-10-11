using BookApp.Application.DTO;
using BookApp.Application.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApp.Application.Interface
{
    public interface IAuthService
    {
        Task<BaseResponse<RegisterDTO>> Register(RegisterDTO model);
        Task<BaseResponse<JwtResponseDTO>> Login(LoginDTO model);
        Task<BaseResponse<JwtResponseDTO>> VerifyRefreshToken(RefreshTokenDTO tokenRequest);
    }
}
