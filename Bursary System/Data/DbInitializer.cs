using Bursary_System.Models;
using Microsoft.AspNetCore.Identity;

namespace Bursary_System.Data
{
    public static class DbInitializer
    {
        public static async Task SeedRolesAsync(RoleManager<IdentityRole> roleManager)
        {
            // Creating roles
            string[] roleNames = { "Admin", "Student", "Staff" };

            foreach (var roleName in roleNames)
            {
                // Check if the role already exists
                var roleExists = await roleManager.RoleExistsAsync(roleName);
                if (!roleExists)
                {
                    // Create the role
                    await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }
        }

        public static async Task SeedAdminUserAsync(UserManager<ApplicationUser> userManager)
        {
            // Check if admin user exists
            var adminUser = await userManager.FindByEmailAsync("admin@bursarysystem.com");
            
            if (adminUser == null)
            {
                // Create admin user
                var admin = new ApplicationUser
                {
                    UserName = "admin@bursarysystem.com",
                    Email = "admin@bursarysystem.com",
                    FirstName = "System",
                    LastName = "Administrator",
                    EmailConfirmed = true
                };

                var result = await userManager.CreateAsync(admin, "Admin@123");
                
                if (result.Succeeded)
                {
                    // Assign admin role
                    await userManager.AddToRoleAsync(admin, "Admin");
                }
            }
        }
    }
} 