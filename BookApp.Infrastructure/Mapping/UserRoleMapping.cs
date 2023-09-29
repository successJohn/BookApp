using BookApp.Application.Utilities;
using BookApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApp.Infrastructure.Mapping
{
    public class UserRoleMapping: IEntityTypeConfiguration<ApplicationUserRole>
    {
        public void Configure(EntityTypeBuilder<ApplicationUserRole> builder)
        {
            var userRole = new List<ApplicationUserRole>
            {
               new ApplicationUserRole
               {
                   UserId = SystemDetails.AdministratorId,
                   RoleId= AppRole.AdminRoleId
               },

               new ApplicationUserRole
               {
                   UserId = SystemDetails.LibrarianId,
                   RoleId = AppRole.LibrarianRoleId
               }
            };


            builder.HasData(userRole);
        }
    }
}
