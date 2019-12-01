using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Registration.Models
{
    public class AuthenticationContext :IdentityDbContext
    {
        private const string localConnectionString = "Server=(LocalDb)\\MSSQLLocalDB;Database=MUBLocalDb;Trusted_Connection=True;MultipleActiveResultSets=true;";
        private readonly DataSeed _DataSeed;
        public AuthenticationContext(DbContextOptions options):base(options)
        {
            _DataSeed = new DataSeed();
        }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(localConnectionString, options => options.EnableRetryOnFailure());
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<PostModel>().HasData(_DataSeed.Getpost());
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole { Name = "Admin", NormalizedName = "Admin".ToUpper() });
            var hasher = new PasswordHasher<ApplicationUser>();
            modelBuilder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                Id = "1",
                UserName = "admin",
                NormalizedUserName = "admin",
                Email = "some-admin-email@nonce.fake",
                NormalizedEmail = "some-admin-email@nonce.fake",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "123456"),
                SecurityStamp = string.Empty
            });

        }

        public DbSet<PostModel> Posts { get; set; }
    }
}
