using Microsoft.AspNetCore.Identity;

namespace WFM.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Password { get; set; }
        public string Role { get; internal set; }
    }
}
