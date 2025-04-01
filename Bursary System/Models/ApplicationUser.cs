using Microsoft.AspNetCore.Identity;

namespace Bursary_System.Models
{
    public class ApplicationUser : IdentityUser
    {
        // Add additional user properties here if needed
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
} 