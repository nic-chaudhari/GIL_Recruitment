using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Web.Mvc;

namespace GIL_Recruitment.Models
{
    public class jobpost
    {
       
            public int id { get; set; }
            public string title { get; set; }
            public string description { get; set; }
            public string age_limit { get; set; }
            public DateTime start_date { get; set; }
            public DateTime end_date { get; set; }
            public string qualification { get; set; }
            public string desirable { get; set; }
            public string experience { get; set; }
      

    }
}

  