using CloudinaryDotNet.Actions;
using CloudinaryDotNet;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hangfire.Logging;
using Microsoft.Extensions.Options;

namespace BookApp.Infrastructure.Services
{
    public class CloudinaryService : ICloudinaryService
    {

        private readonly ILog _logger;
        private readonly CloudinarySettings _cloudinarySettings;

        private readonly Cloudinary _cloudinary;
        private readonly Account _account;

        public CloudinaryService(IOptions<CloudinarySettings> cloudinarySettings)
        {
            _cloudinarySettings = cloudinarySettings.Value;
            _cloudinary = new Cloudinary(_account = SetupCloudinaryAccount());
        }


        public async Task<string> UploadPicture(IFormFile filePath)
        {
            string fileUrl = default;

            if (filePath is null)
            {
                _logger.Error("File path is null");
                return ( "Failed");
            }

            try
            {
                _cloudinary.Api.Secure = true;

                var stream = filePath.OpenReadStream();

                var uploadParams = new ImageUploadParams()
                {
                    File = new FileDescription(filePath.FileName, stream)
                };

                var uploadResult = await _cloudinary.UploadAsync(uploadParams);
                fileUrl = uploadResult.SecureUrl.AbsoluteUri;

                return fileUrl;
            }
            catch (Exception ex)
            {
                _logger.Error($"An Error Occured while uploading file to cloudinary -- {ex.Message}");
                return $"{ex.Message}, An Error Occcured while uploading file to cloudinary";
            }
        }


        private Account SetupCloudinaryAccount()
        {
            return new Account()
            {
                Cloud = _cloudinarySettings.CloudName,
                ApiKey = _cloudinarySettings.ApiKey,
                ApiSecret = _cloudinarySettings.ApiSecret
            };

        }


    }
}
