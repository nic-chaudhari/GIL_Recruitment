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
    public class AllowedExtensionsAttribute : ValidationAttribute
    {
        private readonly string[] _extensions;

        public AllowedExtensionsAttribute(string[] extensions)
        {
            _extensions = extensions;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                var file = value as IFormFile;
                var extension = Path.GetExtension(file.FileName);

                if (!_extensions.Contains(extension.ToLower()))
                {
                    return new ValidationResult($"The file extension {extension} is not allowed.");
                }
            }

            return ValidationResult.Success;
        }
    }
}

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
public enum GenderType
{
    Male,
    Female,
    Other
}

public enum PhysicallyChallengedType
{
    Yes,
    No
}

public enum MaritalStatusType
{
    Single,
    Married,
    Divorced,
    Widowed
}
public class personal_infomodel
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "Please enter a title.")]
        public string? Title { get; set; }

        [Required(ErrorMessage = "Please enter a first name.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "First name must be between 2 and 50 characters.")]
        public string? FirstName { get; set; }

        [StringLength(50, ErrorMessage = "Middle name cannot be more than 50 characters.")]
        public string? MiddleName { get; set; }

        [Required(ErrorMessage = "Please enter a surname.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Surname must be between 2 and 50 characters.")]
        public string? Surname { get; set; }

        [Required(ErrorMessage = "Please enter a mother's name.")]
        public string? MotherName { get; set; }

    [Required(ErrorMessage = "Please select a gender.")]
    public GenderType? Gender { get; set; }


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
    public MaritalStatusType Maritial { get; set; }

    [Required(ErrorMessage = "Please upload a photo.")]
    [DataType(DataType.Upload)]
    [MaxFileSize(2 * 1024 * 1024, ErrorMessage = "Please upload a photo with size less than 2 MB.")]
    [AllowedExtensions(new string[] { ".jpg", ".jpeg", ".png", ".gif" }, ErrorMessage = "Please upload a photo with an allowed extension (jpg, jpeg, png, gif).")]
    public IFormFile Upphoto { get; set; }

    [Required(ErrorMessage = "Please upload a signature.")]
    [DataType(DataType.Upload)]
    [MaxFileSize(1 * 1024 * 1024, ErrorMessage = "Please upload a signature with size less than 1 MB.")]
    [AllowedExtensions(new string[] { ".jpg", ".jpeg", ".png", ".gif" }, ErrorMessage = "Please upload a signature with an allowed extension (jpg, jpeg, png, gif).")]
    public IFormFile? Upsign { get; set; }

    [Required(ErrorMessage = "Please upload a proof.")]
    [DataType(DataType.Upload)]
    [MaxFileSize(2 * 1024 * 1024, ErrorMessage = "Please upload a proof with size less than 2 MB.")]
    [AllowedExtensions(new string[] { ".jpg", ".jpeg", ".png", ".gif" }, ErrorMessage = "Please upload a proof with an allowed extension (jpg, jpeg, png, gif).")]
    public IFormFile? Upproof { get; set; }

    public string? Upphotopath { get; set; }
        public string? Upsignpath { get; set; }
        public string? Upproofpath { get; set; }
    }

