using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Web.Mvc;

namespace GIL_Recruitment.Models
{
    public class jobpost
    {
       
            public int id { get; set; }

            [Required]
            public string title { get; set; }

        [Required]
        public string age_limit { get; set; }
        [Required]
        public DateTime start_date { get; set; }
        [Required]
        public DateTime end_date { get; set; }
        [Required]
        public string qualification { get; set; }
        [Required]
        public string desirable { get; set; }
        [Required]
        public string experience { get; set; }
      

    }
}

  