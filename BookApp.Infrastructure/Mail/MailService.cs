using AutoMapper.Internal;
using BookApp.Application.Interface;
using BookApp.Application.Utilities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApp.Infrastructure.Mail
{
    public class MailService : IMailService
    {
        //private readonly IEncryptService _encrypt;
       // private readonly SmtpSettings _smtpConfigSettings;
        private readonly ISendGridClient _sendGridClient;
        private readonly IConfiguration _configuration;
        private readonly EmailLink _emailLink;

        public MailService(
            //IOptions<SmtpSettings> smtpConfigSettings, 
            IOptions<EmailLink> emailLink, 
            ISendGridClient sendGridClient,
            IConfiguration configuration
           )
        {
            // _smtpConfigSettings = smtpConfigSettings.Value;
            _emailLink = emailLink.Value;
            _sendGridClient = sendGridClient;
            _configuration = configuration;
            //_encrypt = encrypt;    
        }
        
        
        public string GenerateEmailConfirmationLinkAsync(string token, string email)
        {
            string baseUri = _emailLink.BaseUrl;

            var hrefValue = $"{baseUri}/{token}/{email}";

            var link = $"<!DOCTYPE html>\r\n<html>\r\n<head>\r\n   " +
                $" <title>Account Verification</title>\r\n</head>\r\n<body>\r\n  " +
                $"<p>Thank you for signing up! To activate your account, please click the following link:</p>\r\n " +
                $"   <p><a href=\"{hrefValue}\">Verify your email address</a></p>\r\n    <p>" +
                $"If you didn't sign up for an account on our website, please ignore this email.</p>\r\n</body>\r\n</html>\r\n";

            return link;
        }
        
        public async Task<string> SendAccountVerificationEmail(string emailAddress, string firstName ,string confirmationLink)
        {

            string fromEmail = _configuration.GetSection("SmtpSettings").GetSection("FromEmail").Value;
            string fromName = _configuration.GetSection("SmtpSettings").GetSection("FromName").Value;

            var msg = new SendGridMessage()
            {
                From = new EmailAddress(fromEmail, fromName),
                Subject = "Verify your BookApp Account",
                HtmlContent = confirmationLink
            };

            msg.AddTo(emailAddress);

            var response = await _sendGridClient.SendEmailAsync(msg);

            string message = response.IsSuccessStatusCode ? "Email Sent" : "Email Sending Failed";

            return message;
        }

    }
}
