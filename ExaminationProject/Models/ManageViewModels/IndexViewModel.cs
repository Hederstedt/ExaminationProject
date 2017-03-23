using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace ExaminationProject.Models.ManageViewModels
{
    public class IndexViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Nuvarande lösenord ")]
        public string OldPassword { get; set; }

        
        [StringLength(100, ErrorMessage = "Ditt {0} måste vara minst {2} och max {1} tecken långt.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Nytt lösenord")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Säkerställ lösenordet")]
        [Compare("NewPassword", ErrorMessage = "Lösenorden matchar inte varandra.")]
        public string ConfirmPassword { get; set; }

        public IFormFile AvatarImage { get; set; }

    }
}
