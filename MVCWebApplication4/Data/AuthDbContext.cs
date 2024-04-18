using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace mvcRegistrations.Data
{
    public class AuthDbContext : IdentityDbContext<IdentityUser>
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Seed Roles (User, Admin, etc)
            var adminRoleID = "8a01746c-bb47-47d0-8472-ce90930e048f"
;
            var userRoleID = "4e7a1e0d-0972-49fd-99d7-868282d40f13";

            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "ADMIN",  // Change role name to uppercase
                    Id = adminRoleID,
                    ConcurrencyStamp = adminRoleID
                },

                new IdentityRole
                {
                    Name = "User",
                    NormalizedName = "USER",   // Change role name to uppercase
                    Id = userRoleID,
                    ConcurrencyStamp = userRoleID
                }
            };

            builder.Entity<IdentityRole>().HasData(roles);

            // Seed admin user
            var adminID = "8a01746c-bb47-47d0-8472-ce90930e048f";
           
            var adminUser = new IdentityUser
            {
                UserName = "Mehvish33@gmail.com",
                Email = "mehvish33@gmail.com",
                NormalizedEmail = "Mehvish33@gmail.com".ToUpper(),
                NormalizedUserName = "Mehvish33@gmail.com".ToUpper(),
                Id = adminID
            };

            

            adminUser.PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(adminUser, "AdminUser11@");
            

            builder.Entity<IdentityUser>().HasData(adminUser);  // Use builder.Entity<IdentityUser>() for user data

            // Add all roles to admin
            var adminRoles = new List<IdentityUserRole<string>>
            {
                new IdentityUserRole<string>
                {
                    RoleId = userRoleID,
                    UserId = adminID
                },
                new IdentityUserRole<string>
                {
                    RoleId = adminRoleID,
                    UserId = adminID
                }
            };

            builder.Entity<IdentityUserRole<string>>().HasData(adminRoles);  // Use builder.Entity<IdentityUserRole<string>>() for role assignment
        }
    }
}
