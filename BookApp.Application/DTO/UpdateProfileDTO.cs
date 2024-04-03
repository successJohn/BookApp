using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApp.Application.DTO
{
    public class UpdateProfileDTO
    {
        public IFormFile profilePicture { get; set; }
    }
}
