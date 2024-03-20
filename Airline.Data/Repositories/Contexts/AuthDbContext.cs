using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Airline.API.Data.Repositories.Contexts
{
    public class AuthDbContext :IdentityDbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options):base(options)
        {
                
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            CreateRolesAndUsers(builder);
        }

        /// <summary>
        /// Create two roles and two users for testing the API
        /// </summary>
        /// <param name="builder"></param>
        private void CreateRolesAndUsers(ModelBuilder builder)
        {
            //Creating roles using migration
            var customerRoleId = "58e9d2af-002f-4f2a-b9b2-57965110e1d0";
            var adminRoleId = "34720d96-2cb4-4cbb-bb36-6c2e2bebfaaa";

            //Create couple of Roles
            var roles = new List<IdentityRole> {
            new IdentityRole()
            {
                Id =customerRoleId,
                Name = "Customer",
                NormalizedName="Customer".ToUpper(),
                ConcurrencyStamp= customerRoleId
            },
            new IdentityRole()
            {
                Id =adminRoleId,
                Name = "Admin",
                NormalizedName="Admin".ToUpper(),
                ConcurrencyStamp= adminRoleId
            }
            };

            //Seed the Roles when there are users
            builder.Entity<IdentityRole>().HasData(roles);

            var adminUserId = "5881370d-8aca-49c7-aba2-0148911d35f6";
            var customerUserId = "23ce6d2a-4af4-44ab-8f63-1c0f21a0b440";
           
            //Create users
            var admin = new IdentityUser()
            {
                Id = adminUserId,
                UserName = "admin@test.com",
                Email = "admin@test.com",
                NormalizedEmail = "admin@test.com".ToUpper(),
                NormalizedUserName = "admin@test.com".ToUpper()
            };
            admin.PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(admin, "admin@test.com");
            var customer = new IdentityUser()
            {
                Id = customerUserId,
                UserName = "customer@test.com",
                Email = "customer@test.com",
                NormalizedEmail = "customer@test.com".ToUpper(),
                NormalizedUserName = "customer@test.com".ToUpper()
            };
            customer.PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(customer, "customer@test.com");
           

            builder.Entity<IdentityUser>().HasData(admin, customer);



            //Give role to 
            var adminRoles = new List<IdentityUserRole<string>>()
            {
                //--=====================Admin User Role Mapping=================
                new()
                {
                    UserId = adminUserId,
                    RoleId = customerRoleId
                },
                 new()
                {
                    UserId = adminUserId,
                    RoleId = adminRoleId
                },
                //--=====================Customer User Role Mapping=================
                 new()
                {
                    UserId = customerUserId,
                    RoleId = customerRoleId
                }
            };
            builder.Entity<IdentityUserRole<string>>().HasData(adminRoles);
        }
    }
}
