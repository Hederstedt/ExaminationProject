using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExaminationProject.Models
{
    public class ReactObject
    {
        public Guid Id { get; set; }
        public string Header { get; set; }
        public string Text { get; set; }
        public IFormFile file { get; set; }
    }
}
