﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApp.Application.Interface
{
    public interface ICloudinaryService
    {
         Task<string> UploadPicture(IFormFile filePath);
    }
}
