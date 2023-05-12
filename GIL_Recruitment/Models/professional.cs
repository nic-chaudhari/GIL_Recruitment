using Xunit.Sdk;
using System.ComponentModel.DataAnnotations;


namespace GIL_Recruitment.Models
{
    public class professional
    {

        public int id { get; set; }
        [Required(ErrorMessage = "Please enter job sector detail.")]
        public string jobsector { get; set; }
        [Required(ErrorMessage = "Please enter Name of post.")]
        public string nameofpost { get; set; }
        [Required(ErrorMessage = "Please enter Start date.")]
        public DateTime startfrom { get; set; }
        [Required(ErrorMessage = "Please enter End date.")]
        public DateTime endto { get; set; }
        [Required(ErrorMessage = "Please enter Employe name.")]
        public string empname { get; set; }
        [Required(ErrorMessage = "Please enter Contact number.")]
        public string empcontactno { get; set; }
        [Required(ErrorMessage = "Please enter Address.")]
        public string empadd { get; set; }
        [Required(ErrorMessage = "Please enter pincode.")]
        public int emppincode { get; set; }
        [Required(ErrorMessage = "Please enter jobdescription.")]
        public string jobdescription { get; set; }
        [Required(ErrorMessage = "Please enter salary.")]
        public int salary { get; set; }
        [Required(ErrorMessage = "Please Upload experience certificate.")]
        public string upexpcerti { get; set; }

      
    }
}
