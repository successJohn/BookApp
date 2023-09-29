using BookApp.Application.Utilities;
using BookApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BookApp.Application.Utilities.PermissionProvider;

namespace BookApp.Infrastructure.Mapping
{
    public class RoleClaimMapping: IEntityTypeConfiguration<ApplicationRoleClaim>
    {
        private static int counter = 0;
        public void Configure(EntityTypeBuilder<ApplicationRoleClaim> builder)
        {
            SetAdministratorRoleClaim(builder);
            SetLibrarianRoleClaim(builder);
        }

        private void SetAdministratorRoleClaim(EntityTypeBuilder<ApplicationRoleClaim> builder)
        => BuildAndSeedRoleClaim(builder, PermissionProvider.AdministratorPermission(), AppRole.AdminRoleId);

        private void SetLibrarianRoleClaim(EntityTypeBuilder<ApplicationRoleClaim> builder)
       => BuildAndSeedRoleClaim(builder, PermissionProvider.LibrarianPermission(), AppRole.LibrarianRoleId);

        private void BuildAndSeedRoleClaim(EntityTypeBuilder<ApplicationRoleClaim> builder, List<Permission> permissions, Guid roleId)
        {
            var claims = permissions
                .Select(x => new ApplicationRoleClaim
                {
                    Id = ++counter,
                    ClaimValue = x.ToString(),
                    ClaimType = nameof(Permission),
                    RoleId = roleId
                }).ToList();

            builder.HasData(claims);
        }
    }
}
