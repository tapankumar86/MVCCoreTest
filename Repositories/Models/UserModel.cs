using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Models
{
    public class UserModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Enter Name")]
        [RegularExpression("^[a-zA-Z\\s.]+$", ErrorMessage = "Only alphabets and space are allowed")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Please Enter Email")]
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Please Enter Password")]
        [StringLength(30, ErrorMessage = "Must be between 5 and 30 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [StringLength(30, ErrorMessage = "Must be between 5 and 30 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Compare Password doesn't match")]
        public string ConfirmPassword { get; set; }


        [Display(Name = "Mobile Number")]
        [Required(ErrorMessage = "Please Enter Mobile Number")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        public string MobileNo { get; set; }

        [Required(ErrorMessage = "Please choose image")]
        [Display(Name = "Image")]
        public IFormFile ImageFile { get; set; }

        public string Photo { get; set; }


        [StringLength(30, MinimumLength = 4)]
        [Required]
        [RegularExpression("^[a-zA-Z\\s.]+$", ErrorMessage = "Only alphabets and space are allowed")]
        public string Designation { get; set; }


        [Required(ErrorMessage = "Please select country")]
        public int CountryId { get; set; }
        public string CountryName { get; set; }


        [Required(ErrorMessage = "Gender is required.")]
        public string Gender { get; set; }

    }
}
