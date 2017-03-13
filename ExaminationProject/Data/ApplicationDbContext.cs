using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ExaminationProject.Models;
using ExaminationProject.Models.ProjektModels;

namespace ExaminationProject.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ProjectModel> ProjectModels { get; set; }
        public DbSet<ProjectContentModel> ProjectContentModels { get; set; }
        public DbSet<ProjectCommentModel> ProjectCommentModels { get; set; }
        public DbSet<ProjectImageModel> ProjectImageModels { get; set; }
        public DbSet<ProjectHeadersModel> ProjectHeadersModels { get; set; }
        public DbSet<ProjectTextModel> ProjectTextModels { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

        }
    }
}
