using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExaminationProject.Models.ProjektModels
{
    public class ProjectContentModel
    {
        public Guid Id { get; set; }
        public virtual IList<ProjectHeadersModel> Headers { get; set; }
        public virtual IList<ProjectTextModel> Texts { get; set; }
        public virtual IList<ProjectImageModel> WorkImages { get; set; }
    }
}
