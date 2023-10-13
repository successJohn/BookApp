using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApp.Application.Utilities
{
    public class PermissionProvider
    {
        public enum Permission
        {
            UPLOAD_BOOK,
            EDIT_BOOK,
            VIEW_ACCOUNTS,
            USER_MANAGEMENT,
            SETTINGS,
            BOOK_HISTORY,
            DASHBOARD
        }

        public static List<Permission> LibrarianPermission()
        {
            return new List<Permission>
            {
                Permission.UPLOAD_BOOK,
                Permission.EDIT_BOOK,
                Permission.BOOK_HISTORY,
            };
        }

        public static List<Permission> AdministratorPermission()
        {
            return new List<Permission>
            {
                Permission.SETTINGS,
                Permission.DASHBOARD,
                Permission.USER_MANAGEMENT,
                Permission.VIEW_ACCOUNTS,
                Permission.BOOK_HISTORY
            };
        }
    }
}
