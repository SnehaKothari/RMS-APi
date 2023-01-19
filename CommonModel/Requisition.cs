using CsvHelper.Configuration.Attributes;
using System.ComponentModel.DataAnnotations;

namespace recruitmentmanagementsystem.CommonModel
{
    #region Requisition  
    public class Requisition
    {
       
        [Index(1)]
        [Required]

        public int id { get; set; }
        public string role { get; set; }

        
        public string jobdescription { get; set; }

       
        [Required]
        public string skillset { get; set; }

     //   [Required]
        public string notrequired { get; set; }

        [Required]
        public string requiredexperience { get; set; }


        [Required]
        public string qualification { get; set; }

      
        [Required]
        public int vacancies { get; set; }
    }
    #endregion
}
