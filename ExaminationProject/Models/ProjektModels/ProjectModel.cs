using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExaminationProject.Models.ProjektModels
{
    public class ProjectModel
    {
        public Guid Id { get; set; }
        public string ProjectName { get; set; }
        public virtual IList<ProjectContentModel> ProjectContent { get; set; }
        public virtual IList<ProjectCommentModel> Comments { get; set; }
    }
}
