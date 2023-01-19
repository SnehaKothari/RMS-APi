using Microsoft.AspNetCore.Identity;
using recruitmentmanagementsystem.CommonModel;
using System.ComponentModel.DataAnnotations;

namespace recruitmentmanagementsystem.CommonMethods
{
    public class LoginFields
    {
        public int id { get; set; }


        [Key]
        [EmailAddress]
        [Required]
        public  string email_id { get; set; }
        [Required]
        [Compare("ConfirmPassword")]
        public  string password { get ; set; }
        [Required]
        public  string usertype { get; set; }

        public string ConfirmPassword { get; set; } 

      //  public Usertype usertype { get; set; }  
    }
}
