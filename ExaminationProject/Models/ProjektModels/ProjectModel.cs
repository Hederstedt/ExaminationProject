using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExaminationProject.Models.ProjektModels
{
    public class ProjectModel
    {
        public int Id { get; set; }
        public string ProjectName { get; set; }

        public ProjectContentModel ProjectContent { get; set; }
        public ICollection<ProjectCommentModel> Comments { get; set; }
        public ApplicationUser User { get; set; }
    }
}
