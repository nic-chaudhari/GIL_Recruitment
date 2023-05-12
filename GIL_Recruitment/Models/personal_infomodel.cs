using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations;
using GIL_Recruitment;
using Xunit;
using Xunit.Sdk;
using GIL_Recruitment.Models;
using Xunit.Abstractions;

namespace GIL_Recruitment.Models
{
   
[AttributeUsage(AttributeTargets.Property)]
public class MaxFileSizeAttribute : ValidationAttribute
{
    private readonly int _maxFileSize;

    public MaxFileSizeAttribute(int maxFileSize)
    {
        _maxFileSize = maxFileSize;
    }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value != null)
        {
            var file = value as IFormFile;
            if (file != null)
            {
                if (file.Length > _maxFileSize)
                {
                    return new ValidationResult($"The file size should not exceed {_maxFileSize / 1024} KB.");
                }
            }
        }

        return ValidationResult.Success;
    }
}

    public class personal_infomodel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a title.")]
        public string Title { get; set; }

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
    }
}


