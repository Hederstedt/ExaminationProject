using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using ExaminationProject.Models.ProjektModels;

namespace ExaminationProject.Models
{
    public class ApplicationUser : IdentityUser
    {
        public byte[] ProfilePic { get; set; }
        public virtual ICollection<ProjectModel> Projects { get; set; }
    }
}
