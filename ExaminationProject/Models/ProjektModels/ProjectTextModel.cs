using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExaminationProject.Models.ProjektModels
{
    public class ProjectTextModel
    {
        public Guid Id { get; set; }
        public string Text { get; set; }

        public ProjectContentModel ProjectContent { get; set; }
    }
}
