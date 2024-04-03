using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApp.Application.Interface
{
    public interface IMailService
    {
        string GenerateEmailConfirmationLinkAsync(string token, string email);
        Task<string> SendAccountVerificationEmail(string Email, string FirstName,  string emailConfirmationLink);
    }
}
