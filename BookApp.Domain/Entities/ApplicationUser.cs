using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApp.Domain.Entities
{
    public  class ApplicationUser: IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public DateTime RegisteredDate { get; set; }

        public DateTime PasswordResetDate { get; set; }

        public DateTime LastLoginDate { get; set; }

    }

    public class ApplicationRole : IdentityRole
    {

    }
}
