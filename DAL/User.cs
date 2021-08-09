using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public class User : IdentityUser<int>
    {
        [Column(TypeName = "varchar(56)")]
        [StringLength(50, MinimumLength = 4)]
        [Required]
        [Display(Name = "Name")]
        [RegularExpression("^[a-zA-Z\\s.]+$", ErrorMessage = "Only alphabets and space are allowed")]
        public string Name { get; set; }

        [Column(TypeName = "varchar(8)")]
        [Display(Name = "Gender")]
        public string Gender { get; set; }

        [Column(TypeName = "char(10)")]
        [Display(Name = "Mobile Number")]
        [Required(ErrorMessage = "Mobile Number is required.")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        public string MobileNo { get; set; }

        [Column(TypeName = "varchar(48)")]
        [DisplayName("Upload File")]
        public string Photo { get; set; }

        [Column(TypeName = "varchar(32)")]
        [StringLength(30, MinimumLength = 4)]
        [Required]
        [Display(Name = "Designation")]
        [RegularExpression("^[a-zA-Z\\s.]+$", ErrorMessage = "Only alphabets and space are allowed")]
        public string Designation { get; set; }
        public string Country { get; set; }

        [NotMapped]
        public IFormFile ImageFile { get; set; }

        [NotMapped]
        public string[] Roles { get; set; }
    }
}
