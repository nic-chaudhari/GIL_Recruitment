using System.ComponentModel.DataAnnotations;
using Xunit.Sdk;

namespace GIL_Recruitment.Models
{
    public class GraduationInfo
    {

        public int id { get; set; }
        [Required(ErrorMessage = "Please enter Education detail.")]
        public int Edudetail { get; set; }
        [Required(ErrorMessage = "Please enter Degree name.")]
        public string Degname { get; set; }
        [Required(ErrorMessage = "Please enter Percentage.")]
        public int Percentage { get; set; }
        [Required(ErrorMessage = "Please enter Class.")]
        public string Class { get; set; }
        [Required(ErrorMessage = "Please enter University.")]
        public string University { get; set; }
        [Required(ErrorMessage = "Please enter No of trails.")]
        public int Nooftrails { get; set; }
        [Required(ErrorMessage = "Please enter Passing month.")]
        public string Passmonth { get; set; }
        [Required(ErrorMessage = "Please enter Passing Year.")]
        public string Passyear { get; set; }
        [Required(ErrorMessage = "Please Upload Ceritificate.")]
        public string Upcerti { get; set; }
        [Required(ErrorMessage = "Please enter Post graduation detail.")]
        public string pEdudetail { get; set; }
        [Required(ErrorMessage = "Please enter Post graduation degree name.")]
        public string pDegname { get; set; }
        [Required(ErrorMessage = "Please enter Post graduation percentage.")]
        public int pPercentage { get; set; }
        [Required(ErrorMessage = "Please enter Post graduation class.")]
        public string pClass { get; set; }
        [Required(ErrorMessage = "Please enter Post graduation University.")]
        public string pUniversity { get; set; }
        [Required(ErrorMessage = "Please enter Post graduation No of trails.")]
        public int pNooftrails { get; set; }
        [Required(ErrorMessage = "Please enter Post graduation Passing month.")]
        public string pPassmonth { get; set; }
        [Required(ErrorMessage = "Please enter Post graduation Passing Year.")]
        public string pPassyear { get; set; }
        [Required(ErrorMessage = "Please Upload Post graduation certificate .")]
        public string pUpcerti { get; set; }
        public string languagelist { get; set; }

    }

}
