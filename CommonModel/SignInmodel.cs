using System.ComponentModel.DataAnnotations;

namespace recruitmentmanagementsystem.CommonModel
{
    public class SignInmodel
    {

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string usertype { get; set; }
    }
}
