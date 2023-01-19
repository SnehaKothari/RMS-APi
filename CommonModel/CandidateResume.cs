using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace recruitmentmanagementsystem.CommonModel
{
    public class CandidateResume
    {

        [Index(1)]
        [Required]
        public int id { get; set; }
        public string email { get; set; }
        public string resume_name { get; set; }
        public DateTime date_time_of_creation { get; set; }

        public string matched_jd { get; set; }
        public string probability_matching { get; set; }
        public string status { get; set; }
    }
}
