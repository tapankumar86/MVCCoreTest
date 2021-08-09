using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class UserModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Enter Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please Enter Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please Enter Password")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Compare Password doesn't match")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Please Enter Phone Number")]
        public string MobileNo { get; set; }

        
        public string Photo { get; set; }

        [Required(ErrorMessage = "Please choose image")]
        [Display(Name = "Image")]
        public IFormFile ImageFile { get; set; }

        [Required(ErrorMessage = "Please Enter Designation")]
        public string Designation { get; set; }

         [Required(ErrorMessage = "Please Select Country")]
        public int CountryId { get; set; }
       
        public string CountryName { get; set; }

        [Required(ErrorMessage = "Please Choose Gender")]
        public string Gender { get; set; }
    }
}
