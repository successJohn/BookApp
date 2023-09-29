using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApp.Application.Utilities
{
    public class SystemDetails
    {
        public const string AdministratorEmail = "administrator@bookapi.com";
        public static readonly Guid AdministratorId = Guid.Parse("3fb897c8-c25d-4328-9813-cb1544369fba");

        public const string LibrarianEmail = "librarian@bookapi.com";
        public static readonly Guid LibrarianId = Guid.Parse("e7d58c75-18bc-4868-b54d-0a1fdf8fe94d");
    }
}
