using System.ComponentModel.DataAnnotations;

namespace recruitmentmanagementsystem.CommonModel
{
    public class ForgotPassword
    {
        [Required,EmailAddress,Display(Name ="Registered email address")]
        public string email_address { get; set; }

    }
}
