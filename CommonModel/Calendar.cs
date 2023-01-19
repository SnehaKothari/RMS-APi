using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace recruitmentmanagementsystem.CommonModel
{
    public class Calendar
    {   
        [Required]
        [Key]
        public string id { get; set; }

        [EmailAddress]
        public string email { get; set; }

        public string link { get; set; }

        public string description { get; set; }

        public DateTime starttime { get; set; }

        public DateTime endtime { get; set; }

        public string status { get; set; }








    }
}
