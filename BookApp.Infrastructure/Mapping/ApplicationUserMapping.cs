using BookApp.Application.Utilities;
using BookApp.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApp.Infrastructure.Mapping
{
    internal class ApplicationUserMapping:IEntityTypeConfiguration<ApplicationUser>
    {
        public PasswordHasher<ApplicationUser> Hasher { get; set; } = new PasswordHasher<ApplicationUser>();

        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            // seed default users
            var users = new List<ApplicationUser>
            {
                // ADMIN
                new ApplicationUser
                {
                    FirstName = "BookAPI",
                    LastName = "Admin",
                    Id = SystemDetails.AdministratorId,
                    Email = SystemDetails.AdministratorEmail,
                    EmailConfirmed = true,
                    NormalizedEmail = SystemDetails.AdministratorEmail.ToUpper(),
                    UserName = SystemDetails.AdministratorEmail,
                    NormalizedUserName = SystemDetails.AdministratorEmail.ToUpper(),
                    TwoFactorEnabled = false,
                    PhoneNumberConfirmed = true,
                    PasswordHash = Hasher.HashPassword(null, "BookApi_1"),
                   // SecurityStamp = "99ae0c45-d682-4542-9ba7-1281e471916b",
                },
                // lIBRARIAN
                new ApplicationUser
                {
                    FirstName = "BookAPI",
                    LastName = "Librarian",
                    Id = SystemDetails.LibrarianId,
                    Email = SystemDetails.LibrarianEmail,
                    EmailConfirmed = true,
                    NormalizedEmail = SystemDetails.LibrarianEmail.ToUpper(),
                    UserName = SystemDetails.LibrarianEmail,
                    NormalizedUserName = SystemDetails.LibrarianEmail.ToUpper(),
                    TwoFactorEnabled = false,
                    PhoneNumberConfirmed = true,
                    PasswordHash = Hasher.HashPassword(null, "BookApi_1"),
                   // SecurityStamp = "016020e3-5c50-40b4-9e66-bba56c9f5bf2",
                },

            };

            builder.HasData(users);
        }
    }
}
