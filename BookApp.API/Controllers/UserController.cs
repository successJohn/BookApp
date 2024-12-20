﻿using BookApp.Application.DTO;
using BookApp.Application.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController    {
        private readonly IUserService _userservice;
        public UserController(IUserService userservice)
        {

            _userservice = userservice;

        }
        [HttpPut]
        [Route("changepassword")]
        public async Task<IActionResult> ChangePassword (ChangePasswordDTO model)
        {
            return ReturnResponse(await _userservice.ChangePassword(model));
        }

        
        [HttpPost]
        [Route("confirmEmail/{token}/{email}")]
        public async Task<IActionResult> ConfirmEmail(string token,string email)
        {
            return ReturnResponse(await _userservice.ConfirmEmail(token, email));
        }

        [HttpPost]
        [Route("uploadProfile")]
        public async Task<IActionResult> UploadProfile(string userId, IFormFile filePath)
        {
            return ReturnResponse(await _userservice.UpdateProfile(userId, filePath));
        }

    }
}
