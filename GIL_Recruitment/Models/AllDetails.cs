using System.ComponentModel.DataAnnotations;
using Xunit.Sdk;

namespace GIL_Recruitment.Models
{
    public class AllDetails
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a title.")]
        public string Title { get; set; }

        public string title { get; set; }

        [Required(ErrorMessage = "Please enter a first name.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "First name must be between 2 and 50 characters.")]
        public string FirstName { get; set; }

        [StringLength(50, ErrorMessage = "Middle name cannot be more than 50 characters.")]
        public string MiddleName { get; set; }

        [Required(ErrorMessage = "Please enter a surname.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Surname must be between 2 and 50 characters.")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Please enter a mother's name.")]
        public string MotherName { get; set; }

        [Required(ErrorMessage = "Please select a gender.")]
        public String Gender { get; set; }

        [Required(ErrorMessage = "Please enter a date of birth.")]
        [DataType(DataType.Date, ErrorMessage = "Please enter a valid date.")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Please enter a nationality.")]
        public string Nationality { get; set; }

        [Required(ErrorMessage = "Please enter a contact number.")]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Please enter a valid 10-digit phone number.")]
        public string ContactNo { get; set; }

        [RegularExpression(@"^(\d{10})?$", ErrorMessage = "Please enter a valid 10-digit phone number or leave this field blank.")]
        public string AlternateNo { get; set; }

        [Required(ErrorMessage = "Please enter a caste.")]
        public string Cast { get; set; }

        [Required(ErrorMessage = "Please enter a physical challenge.")]
        public string Phychall { get; set; }

        [Required(ErrorMessage = "Please enter a present address.")]
        public string PresentAdd { get; set; }

        [Required(ErrorMessage = "Please enter a permanent address.")]
        public string PermanentAdd { get; set; }

        [Required(ErrorMessage = "Please select a marital status.")]
        public String Maritial { get; set; }

        [Required(ErrorMessage = "Please upload a photo.")]
        [DataType(DataType.Upload)]
        [MaxFileSize(2 * 1024 * 1024, ErrorMessage = "Please upload a photo with size less than 2 MB.")]

        public string Upphoto { get; set; }

        [Required(ErrorMessage = "Please upload a signature.")]
        [DataType(DataType.Upload)]
        [MaxFileSize(1 * 1024 * 1024, ErrorMessage = "Please upload a signature with size less than 1 MB.")]

        public string Upsign { get; set; }

        [Required(ErrorMessage = "Please upload a proof.")]
        [DataType(DataType.Upload)]
        [MaxFileSize(2 * 1024 * 1024, ErrorMessage = "Please upload a proof with size less than 2 MB.")]

        public string Upproof { get; set; }
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
