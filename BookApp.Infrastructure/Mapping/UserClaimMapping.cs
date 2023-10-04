using BookApp.Application.Utilities;
using BookApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BookApp.Application.Utilities.PermissionProvider;

namespace BookApp.Infrastructure.Mapping
{
    public class UserClaimMapping: IEntityTypeConfiguration<ApplicationUserClaim>
    {
        private static int counter = 0;
        public void Configure(EntityTypeBuilder<ApplicationUserClaim> builder)
        {
            SetAdministratorClaim(builder);
            SetLibrarianClaim(builder);
        }

        private void SetAdministratorClaim(EntityTypeBuilder<ApplicationUserClaim> builder)
        => BuildAndSeedUserClaim(builder, PermissionProvider.AdministratorPermission(), SystemDetails.AdministratorId);

        private void SetLibrarianClaim(EntityTypeBuilder<ApplicationUserClaim> builder)
       => BuildAndSeedUserClaim(builder, PermissionProvider.LibrarianPermission(), SystemDetails.LibrarianId);

        private void BuildAndSeedUserClaim(EntityTypeBuilder<ApplicationUserClaim> builder, List<Permission> permissions, Guid userId)
        {
            var claims = permissions
                .Select(x => new ApplicationUserClaim
                {
                    Id = ++counter,
                    ClaimValue = x.ToString(),
                    ClaimType = nameof(Permission),
                   UserId = userId
                }).ToList();

            builder.HasData(claims);
        }
    }
}
