using Microsoft.AspNetCore.Identity;

namespace recruitmentmanagementsystem.CommonModel
{
    public class ApplicationUser: IdentityUser
    {
        public string usertype { get; set; }
    }
}
