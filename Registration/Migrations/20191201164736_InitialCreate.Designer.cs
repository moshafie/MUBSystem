﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Registration.Models;

namespace Registration.Migrations
{
    [DbContext(typeof(AuthenticationContext))]
    [Migration("20191201164736_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");

                    b.HasData(
                        new
                        {
                            Id = "c934bc32-f2c1-428b-a84d-ece62febf08d",
                            ConcurrencyStamp = "3a0f3375-d7ef-49d0-8386-6f5acad90a3c",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasMaxLength(128);

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Registration.Models.PostModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Author");

                    b.Property<string>("Body");

                    b.Property<DateTime>("DateCreated");

                    b.Property<string>("ImageUrl");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Posts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Body = "Because the article system is so complex and often idiosyncratic, it is especially difficult for non-native English speakers to master. This handout explains three basic rules that are the foundation of the article system and two basic questions that will help you choose the correct article in your writing. It provides examples of articles being used in context, and it ends with a section on special considerations for nouns in academic writing.",
                            DateCreated = new DateTime(2019, 12, 1, 16, 47, 35, 733, DateTimeKind.Utc).AddTicks(863),
                            ImageUrl = "https://picsum.photos/id/1011/5472/3648",
                            Title = "article system"
                        },
                        new
                        {
                            Id = 2,
                            Body = "Because the article system is so complex and often idiosyncratic, it is especially difficult for non-native English speakers to master. This handout explains three basic rules that are the foundation of the article system and two basic questions that will help you choose the correct article in your writing. It provides examples of articles being used in context, and it ends with a section on special considerations for nouns in academic writing.",
                            DateCreated = new DateTime(2019, 12, 1, 16, 47, 35, 741, DateTimeKind.Utc).AddTicks(1315),
                            ImageUrl = "https://picsum.photos/id/1012/3973/2639",
                            Title = "article system post"
                        },
                        new
                        {
                            Id = 3,
                            Body = "Because the article system is so complex and often idiosyncratic, it is especially difficult for non-native English speakers to master. This handout explains three basic rules that are the foundation of the article system and two basic questions that will help you choose the correct article in your writing. It provides examples of articles being used in context, and it ends with a section on special considerations for nouns in academic writing.",
                            DateCreated = new DateTime(2019, 12, 1, 16, 47, 35, 741, DateTimeKind.Utc).AddTicks(1546),
                            ImageUrl = "https://picsum.photos/id/1019/5472/3648",
                            Title = "article system post"
                        },
                        new
                        {
                            Id = 4,
                            Body = "Because the article system is so complex and often idiosyncratic, it is especially difficult for non-native English speakers to master. This handout explains three basic rules that are the foundation of the article system and two basic questions that will help you choose the correct article in your writing. It provides examples of articles being used in context, and it ends with a section on special considerations for nouns in academic writing.",
                            DateCreated = new DateTime(2019, 12, 1, 16, 47, 35, 741, DateTimeKind.Utc).AddTicks(1587),
                            ImageUrl = "https://picsum.photos/id/1/5616/3744",
                            Title = "article system post"
                        },
                        new
                        {
                            Id = 5,
                            Body = "Because the article system is so complex and often idiosyncratic, it is especially difficult for non-native English speakers to master. This handout explains three basic rules that are the foundation of the article system and two basic questions that will help you choose the correct article in your writing. It provides examples of articles being used in context, and it ends with a section on special considerations for nouns in academic writing.",
                            DateCreated = new DateTime(2019, 12, 1, 16, 47, 35, 741, DateTimeKind.Utc).AddTicks(1625),
                            ImageUrl = "https://picsum.photos/id/1001/5616/3744",
                            Title = "article system post"
                        },
                        new
                        {
                            Id = 6,
                            Body = "Because the article system is so complex and often idiosyncratic, it is especially difficult for non-native English speakers to master. This handout explains three basic rules that are the foundation of the article system and two basic questions that will help you choose the correct article in your writing. It provides examples of articles being used in context, and it ends with a section on special considerations for nouns in academic writing.",
                            DateCreated = new DateTime(2019, 12, 1, 16, 47, 35, 741, DateTimeKind.Utc).AddTicks(1723),
                            ImageUrl = "https://picsum.photos/id/1003/1181/1772",
                            Title = "article system post"
                        },
                        new
                        {
                            Id = 7,
                            Body = "Because the article system is so complex and often idiosyncratic, it is especially difficult for non-native English speakers to master. This handout explains three basic rules that are the foundation of the article system and two basic questions that will help you choose the correct article in your writing. It provides examples of articles being used in context, and it ends with a section on special considerations for nouns in academic writing.",
                            DateCreated = new DateTime(2019, 12, 1, 16, 47, 35, 741, DateTimeKind.Utc).AddTicks(1754),
                            ImageUrl = "https://picsum.photos/id/1005/5760/3840",
                            Title = "article system post"
                        },
                        new
                        {
                            Id = 8,
                            Body = "Because the article system is so complex and often idiosyncratic, it is especially difficult for non-native English speakers to master. This handout explains three basic rules that are the foundation of the article system and two basic questions that will help you choose the correct article in your writing. It provides examples of articles being used in context, and it ends with a section on special considerations for nouns in academic writing.",
                            DateCreated = new DateTime(2019, 12, 1, 16, 47, 35, 741, DateTimeKind.Utc).AddTicks(1787),
                            ImageUrl = "https://picsum.photos/id/1026/4621/3070",
                            Title = "article system post"
                        },
                        new
                        {
                            Id = 9,
                            Body = "Because the article system is so complex and often idiosyncratic, it is especially difficult for non-native English speakers to master. This handout explains three basic rules that are the foundation of the article system and two basic questions that will help you choose the correct article in your writing. It provides examples of articles being used in context, and it ends with a section on special considerations for nouns in academic writing.",
                            DateCreated = new DateTime(2019, 12, 1, 16, 47, 35, 741, DateTimeKind.Utc).AddTicks(1815),
                            ImageUrl = "https://picsum.photos/id/1038/3914/5863",
                            Title = "article system post"
                        },
                        new
                        {
                            Id = 10,
                            Body = "Because the article system is so complex and often idiosyncratic, it is especially difficult for non-native English speakers to master. This handout explains three basic rules that are the foundation of the article system and two basic questions that will help you choose the correct article in your writing. It provides examples of articles being used in context, and it ends with a section on special considerations for nouns in academic writing.",
                            DateCreated = new DateTime(2019, 12, 1, 16, 47, 35, 741, DateTimeKind.Utc).AddTicks(1844),
                            ImageUrl = "https://picsum.photos/id/1068/7117/4090",
                            Title = "article system post"
                        },
                        new
                        {
                            Id = 11,
                            Body = "Because the article system is so complex and often idiosyncratic, it is especially difficult for non-native English speakers to master. This handout explains three basic rules that are the foundation of the article system and two basic questions that will help you choose the correct article in your writing. It provides examples of articles being used in context, and it ends with a section on special considerations for nouns in academic writing.",
                            DateCreated = new DateTime(2019, 12, 1, 16, 47, 35, 741, DateTimeKind.Utc).AddTicks(1908),
                            ImageUrl = "https://picsum.photos/id/1076/4835/3223",
                            Title = "article system post"
                        });
                });

            modelBuilder.Entity("Registration.Models.ApplicationUser", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<string>("fullName")
                        .HasColumnType("nvarchar(150)");

                    b.HasDiscriminator().HasValue("ApplicationUser");

                    b.HasData(
                        new
                        {
                            Id = "1",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "ecf869c1-9f7a-4064-bcb2-612e451b093d",
                            Email = "some-admin-email@nonce.fake",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "some-admin-email@nonce.fake",
                            NormalizedUserName = "admin",
                            PasswordHash = "AQAAAAEAACcQAAAAEJ/13rqc+BXeRMYp0VB+YRAHTNLBBoHa9IEf3Zpqw2x5dqh14is3DScVZlmxSgQxYQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "",
                            TwoFactorEnabled = false,
                            UserName = "admin"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
