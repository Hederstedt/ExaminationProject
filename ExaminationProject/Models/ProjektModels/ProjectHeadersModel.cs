using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExaminationProject.Models.ProjektModels
{
    public class ProjectHeadersModel
    {
        public Guid Id { get; set; }
        public string Header { get; set; }
        public virtual ProjectContentModel ProjectContent { get; set; }
    }
}
