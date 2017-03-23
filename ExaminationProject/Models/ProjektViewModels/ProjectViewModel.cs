using ExaminationProject.Models.ProjektModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExaminationProject.Models.ProjektViewModels
{
    public class ProjectViewModel
    {
        public int Id { get; private set; }
        public string ProjectName { get; private set; }

        public ProjectContentModel ProjectContent { get; private set; }
        public IList<ProjectCommentModel> Comments { get; private set; }

        public ProjectViewModel(ProjectModel pModel)
        {
            Id = pModel.Id;
            ProjectName = pModel.ProjectName;
            ProjectContent = pModel.ProjectContent;
            Comments = pModel.Comments.ToList();
        }
    }
}
