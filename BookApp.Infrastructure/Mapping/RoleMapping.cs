using BookApp.Application.Utilities;
using BookApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApp.Infrastructure.Mapping
{
    public class RoleMapping: IEntityTypeConfiguration<ApplicationRole>
    {
        public void Configure(EntityTypeBuilder<ApplicationRole> builder)
        {
            var roles = new List<ApplicationRole>
            {
                new ApplicationRole
                {
                    Id = AppRole.AdminRoleId,
                    Name = AppRole.ADMINISTRATOR.ToString(),
                    NormalizedName = AppRole.ADMINISTRATOR.ToString(),
                },
                new ApplicationRole
                {
                    Id = AppRole.LibrarianRoleId,
                    Name = AppRole.LIBRARIAN.ToString(),
                    NormalizedName = AppRole.LIBRARIAN.ToString(),
                }
            };

            builder.HasData(roles);
        }
    }
}
