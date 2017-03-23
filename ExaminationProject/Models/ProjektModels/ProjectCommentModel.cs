using ExaminationProject.Models.ProjektModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExaminationProject.Models
{
    public class ProjectCommentModel
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public string Text { get; set; }
        public DateTime TimeStamp { get; set; }

        public virtual ProjectModel Project { get; set; }
    }
}
