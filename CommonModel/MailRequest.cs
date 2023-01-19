using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace recruitmentmanagementsystem.CommonModel
{
    public class MailRequest
    {
        public string ToEmail { get; set; }
        public string Subject ="Please set your Password by clicking below link";
        public string Body ="click here to reset your password http://localhost:3000/changepassword ";

    }
}
