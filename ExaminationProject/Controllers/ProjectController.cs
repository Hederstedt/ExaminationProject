using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ExaminationProject.Models;
using ExaminationProject.Data;
using Microsoft.AspNetCore.Identity;
using ExaminationProject.Models.ProjektModels;
using System.Collections;
using Microsoft.Extensions.ProjectModel;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ExaminationProject.Controllers
{
    public class ProjectController : Controller
    {      
        private ApplicationDbContext _db;
        private UserManager<ApplicationUser> _userManager;
        private IList<ReactObject> _objlsit;
        public List<ReactObject> test = new List<ReactObject>();

        public ProjectController(ApplicationDbContext db, UserManager<ApplicationUser> userManager)
        {
            _db = db;
            _userManager = userManager;
            _objlsit = new List<ReactObject>()
            {
                new ReactObject
                {
                    file = null,
                    Text = "temp",
                    Header = "testrub"
                },
            };
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        ///project/data
        [Route("project/data")]
        [HttpPost]
        public async Task<IActionResult> AddProjectAsync(ReactObject data)
        {
            var user = await GetCurrentUserAsync();
            if (user != null)
            {
       
                ProjectHeadersModel header = new ProjectHeadersModel()
                {
                    Header = data.Header,
                    Id = new Guid(),
                   // ProjectContent = content
                                       
                };
                ProjectTextModel text = new ProjectTextModel()
                {
                    Id = new Guid(),
                    Text = data.Text,
                   // ProjectContent = content

                };
                ProjectImageModel image = new ProjectImageModel()
                {
                    Id = new Guid(),
                    WorkImage = null,
                   // ProjectContent = content
                    
                };

                ProjectContentModel content = new ProjectContentModel();
                //content.Headers.Add(header);
                //content.Texts.Add(text);
                //content.WorkImages.Add(image);

                ProjectModel p1 = new ProjectModel()
                {
                    User = user,
                    ProjectName = "första",
                    ProjectContent = content
                };
                user.Projects = new List<ProjectModel>
                {
                    p1
                };
                _db.SaveChanges();
            }
            ReactObject obj = new ReactObject();
            obj = data;
            obj.Id = new Guid();
            _objlsit.Add(obj);
            test.Add(obj);
            return Content("Success :)");
        }
        private Task<ApplicationUser> GetCurrentUserAsync()
        {
            return _userManager.GetUserAsync(HttpContext.User);
        }

    }
}
