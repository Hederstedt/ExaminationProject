using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExaminationProject.Models.ProjektModels
{
    public class ProjectContentModel
    {
        public int Id { get; set; }
        public ICollection<ProjectHeadersModel> Headers { get; set; }
        public ICollection<ProjectTextModel> Texts { get; set; }
        public ICollection<ProjectImageModel> WorkImages { get; set; }
        /// <summary>
        /// Nav-props
        /// </summary>
        public virtual int ProjectModelId { get; set; }
        public virtual ProjectModel ProjectModel { get; set; }
    }
}
