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
using ExaminationProject.HelperClasses;
using Microsoft.AspNetCore.Http;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ExaminationProject.Controllers
{
    public class ProjectController : Controller
    {
        private ApplicationDbContext _db;
        private UserManager<ApplicationUser> _userManager;
        public bool first = true;
        public int Idd;

        public ProjectController(ApplicationDbContext db, UserManager<ApplicationUser> userManager)
        {
            _db = db;
            _userManager = userManager;

        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        [Route("project/test")]
        [HttpPost]
        public IActionResult AddProjectArray(IEnumerable<ReactObject> objects)
        {
            foreach (var item in objects)
            {
                var b = item;
            }
            return Content("Success :)");
        }
        ///project/data
        [Route("project/data")]
        [HttpPost]
        public async Task<IActionResult> AddProjectAsync(ReactObject data)
        {

            CreateObj(data);
            var user = await GetCurrentUserAsync();
            if (user != null)
            {
                ProjectHeadersModel newHeader = CreateHeader(data.Header, _db);
                ProjectTextModel newText = CreateText(data.Text, _db);
                ProjectImageModel newImag = await CreateImageAsync(data.File, _db);

                ProjectContentModel newContent = CreateContent(newHeader, newText, newImag, _db);
                ProjectModel newProject = new ProjectModel()
                {
                    User = user,
                    ProjectName = data.Title,
                    ProjectContent = newContent
                };
                _db.ProjectModels.Add(newProject);
                user.Projects.Add(newProject);
                _db.SaveChanges();
            }
            return Content("Success :)");
        }

        private ProjectContentModel CreateContent(ProjectHeadersModel newHeader, ProjectTextModel newText, ProjectImageModel newImag, ApplicationDbContext db)
        {
            ProjectContentModel tempContent = new ProjectContentModel()
            {
                Headers = new List<ProjectHeadersModel> { newHeader },
                Texts = new List<ProjectTextModel> {newText },
                WorkImages = new List<ProjectImageModel> {newImag },                      
            };
            db.ProjectContentModels.Add(tempContent);
            return tempContent;
        }

        private async Task<ProjectImageModel> CreateImageAsync(IFormFile file, ApplicationDbContext db)
        {
            ProjectImageModel tempImage = new ProjectImageModel()
            {
                Id = new Guid(),
                WorkImage = await file.CreateImageFileAsync()
            };
            db.ProjectImageModels.Add(tempImage);
            return tempImage;
        }

        private ProjectTextModel CreateText(string text, ApplicationDbContext db)
        {
            ProjectTextModel tempText = new ProjectTextModel()
            {
                Text = text,
                Id = new Guid()
            };
            db.ProjectTextModels.Add(tempText);
            return tempText;
        }

        private ProjectHeadersModel CreateHeader(string header, ApplicationDbContext db)
        {
            ProjectHeadersModel tempHeader = new ProjectHeadersModel()
            {
                Header = header,
                Id = new Guid()
            };
            db.ProjectHeadersModels.Add(tempHeader);
            return tempHeader;
        }

        private Task<ApplicationUser> GetCurrentUserAsync()
        {
            return _userManager.GetUserAsync(HttpContext.User);
        }
        private void CreateObj(ReactObject fromReact)
        {
            List<ReactObject> tmpLista = new List<ReactObject>();

            ReactObject newObj = new ReactObject();
            newObj.Id = Idd++;
            newObj.Header = fromReact.Header;
            newObj.File = fromReact.File;
            newObj.Text = fromReact.Text;
            tmpLista.Add(newObj);

        }
    }

}

