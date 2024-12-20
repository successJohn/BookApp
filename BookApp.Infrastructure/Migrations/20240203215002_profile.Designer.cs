﻿// <auto-generated />
using System;
using BookApp.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BookApp.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240203215002_profile")]
    partial class profile
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.22")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BookApp.Domain.Entities.ApplicationRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("a1b6b6b0-0825-4975-a93d-df3dc86f8cc7"),
                            ConcurrencyStamp = "304cd6d9378b4cfbbbe4b52d89dfc7be",
                            Name = "ADMINISTRATOR",
                            NormalizedName = "ADMINISTRATOR"
                        },
                        new
                        {
                            Id = new Guid("131e8b31-59a7-4c80-9b71-08b60e951e5c"),
                            ConcurrencyStamp = "a551ba5443d24fccb1bca53b63d7ca4d",
                            Name = "LIBRARIAN",
                            NormalizedName = "LIBRARIAN"
                        });
                });

            modelBuilder.Entity("BookApp.Domain.Entities.ApplicationUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastLoginDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PasswordResetDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("ProfilePicture")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RegisteredDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("3fb897c8-c25d-4328-9813-cb1544369fba"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "ba8271c4-3db7-4161-bf2d-50dcde6fb7ec",
                            Email = "administrator@bookapi.com",
                            EmailConfirmed = true,
                            FirstName = "BookAPI",
                            LastLoginDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastName = "Admin",
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMINISTRATOR@BOOKAPI.COM",
                            NormalizedUserName = "ADMINISTRATOR@BOOKAPI.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAELIazT5OD8QBJzWXvCgmPV/lPyKWyxNV3wPmyH97smGCcdYgsFWUf/XN7Fr0t4DXRg==",
                            PasswordResetDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PhoneNumberConfirmed = true,
                            ProfilePicture = "",
                            RegisteredDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TwoFactorEnabled = false,
                            UserName = "administrator@bookapi.com"
                        },
                        new
                        {
                            Id = new Guid("e7d58c75-18bc-4868-b54d-0a1fdf8fe94d"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "15cac0ad-5cb8-43b9-9a66-c5ba03d5acee",
                            Email = "librarian@bookapi.com",
                            EmailConfirmed = true,
                            FirstName = "BookAPI",
                            LastLoginDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastName = "Librarian",
                            LockoutEnabled = false,
                            NormalizedEmail = "LIBRARIAN@BOOKAPI.COM",
                            NormalizedUserName = "LIBRARIAN@BOOKAPI.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAENOItd0mZ0WuwE8Q0MDo2ExWE9T8YmXeWxVmKrIfxXviOBDdGWx81mvN3XXZKT1P1g==",
                            PasswordResetDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PhoneNumberConfirmed = true,
                            ProfilePicture = "",
                            RegisteredDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TwoFactorEnabled = false,
                            UserName = "librarian@bookapi.com"
                        });
                });

            modelBuilder.Entity("BookApp.Domain.Entities.Book", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ISBN")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("PublicationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("QuantityInStock")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isAvailable")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("BookApp.Domain.Entities.BookHistory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BookId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CheckOutDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ExpectedReturnDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ReturnDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("UserId");

                    b.ToTable("BookHistories");
                });

            modelBuilder.Entity("BookApp.Domain.Entities.RefreshToken", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ExpiresAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("IssuedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("RefreshTokens");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityRoleClaim<Guid>");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUserClaim<Guid>");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUserRole<Guid>");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("BookApp.Domain.Entities.ApplicationRoleClaim", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>");

                    b.HasDiscriminator().HasValue("ApplicationRoleClaim");

                    b.HasData(
                        new
                        {
                            Id = 9,
                            ClaimType = "Permission",
                            ClaimValue = "SETTINGS",
                            RoleId = new Guid("a1b6b6b0-0825-4975-a93d-df3dc86f8cc7")
                        },
                        new
                        {
                            Id = 10,
                            ClaimType = "Permission",
                            ClaimValue = "DASHBOARD",
                            RoleId = new Guid("a1b6b6b0-0825-4975-a93d-df3dc86f8cc7")
                        },
                        new
                        {
                            Id = 11,
                            ClaimType = "Permission",
                            ClaimValue = "USER_MANAGEMENT",
                            RoleId = new Guid("a1b6b6b0-0825-4975-a93d-df3dc86f8cc7")
                        },
                        new
                        {
                            Id = 12,
                            ClaimType = "Permission",
                            ClaimValue = "VIEW_ACCOUNTS",
                            RoleId = new Guid("a1b6b6b0-0825-4975-a93d-df3dc86f8cc7")
                        },
                        new
                        {
                            Id = 13,
                            ClaimType = "Permission",
                            ClaimValue = "BOOK_HISTORY",
                            RoleId = new Guid("a1b6b6b0-0825-4975-a93d-df3dc86f8cc7")
                        },
                        new
                        {
                            Id = 14,
                            ClaimType = "Permission",
                            ClaimValue = "UPLOAD_BOOK",
                            RoleId = new Guid("131e8b31-59a7-4c80-9b71-08b60e951e5c")
                        },
                        new
                        {
                            Id = 15,
                            ClaimType = "Permission",
                            ClaimValue = "EDIT_BOOK",
                            RoleId = new Guid("131e8b31-59a7-4c80-9b71-08b60e951e5c")
                        },
                        new
                        {
                            Id = 16,
                            ClaimType = "Permission",
                            ClaimValue = "BOOK_HISTORY",
                            RoleId = new Guid("131e8b31-59a7-4c80-9b71-08b60e951e5c")
                        });
                });

            modelBuilder.Entity("BookApp.Domain.Entities.ApplicationUserClaim", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>");

                    b.HasDiscriminator().HasValue("ApplicationUserClaim");

                    b.HasData(
                        new
                        {
                            Id = 9,
                            ClaimType = "Permission",
                            ClaimValue = "SETTINGS",
                            UserId = new Guid("3fb897c8-c25d-4328-9813-cb1544369fba")
                        },
                        new
                        {
                            Id = 10,
                            ClaimType = "Permission",
                            ClaimValue = "DASHBOARD",
                            UserId = new Guid("3fb897c8-c25d-4328-9813-cb1544369fba")
                        },
                        new
                        {
                            Id = 11,
                            ClaimType = "Permission",
                            ClaimValue = "USER_MANAGEMENT",
                            UserId = new Guid("3fb897c8-c25d-4328-9813-cb1544369fba")
                        },
                        new
                        {
                            Id = 12,
                            ClaimType = "Permission",
                            ClaimValue = "VIEW_ACCOUNTS",
                            UserId = new Guid("3fb897c8-c25d-4328-9813-cb1544369fba")
                        },
                        new
                        {
                            Id = 13,
                            ClaimType = "Permission",
                            ClaimValue = "BOOK_HISTORY",
                            UserId = new Guid("3fb897c8-c25d-4328-9813-cb1544369fba")
                        },
                        new
                        {
                            Id = 14,
                            ClaimType = "Permission",
                            ClaimValue = "UPLOAD_BOOK",
                            UserId = new Guid("e7d58c75-18bc-4868-b54d-0a1fdf8fe94d")
                        },
                        new
                        {
                            Id = 15,
                            ClaimType = "Permission",
                            ClaimValue = "EDIT_BOOK",
                            UserId = new Guid("e7d58c75-18bc-4868-b54d-0a1fdf8fe94d")
                        },
                        new
                        {
                            Id = 16,
                            ClaimType = "Permission",
                            ClaimValue = "BOOK_HISTORY",
                            UserId = new Guid("e7d58c75-18bc-4868-b54d-0a1fdf8fe94d")
                        });
                });

            modelBuilder.Entity("BookApp.Domain.Entities.ApplicationUserRole", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>");

                    b.HasDiscriminator().HasValue("ApplicationUserRole");

                    b.HasData(
                        new
                        {
                            UserId = new Guid("3fb897c8-c25d-4328-9813-cb1544369fba"),
                            RoleId = new Guid("a1b6b6b0-0825-4975-a93d-df3dc86f8cc7")
                        },
                        new
                        {
                            UserId = new Guid("e7d58c75-18bc-4868-b54d-0a1fdf8fe94d"),
                            RoleId = new Guid("131e8b31-59a7-4c80-9b71-08b60e951e5c")
                        });
                });

            modelBuilder.Entity("BookApp.Domain.Entities.BookHistory", b =>
                {
                    b.HasOne("BookApp.Domain.Entities.Book", "Book")
                        .WithMany("BookHistories")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("BookApp.Domain.Entities.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("BookApp.Domain.Entities.ApplicationRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("BookApp.Domain.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("BookApp.Domain.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("BookApp.Domain.Entities.ApplicationRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookApp.Domain.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("BookApp.Domain.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BookApp.Domain.Entities.Book", b =>
                {
                    b.Navigation("BookHistories");
                });
#pragma warning restore 612, 618
        }
    }
}
