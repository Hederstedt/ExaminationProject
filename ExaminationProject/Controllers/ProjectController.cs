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
        public async Task<IActionResult> AddProjectArrayAsync(ReactObject data)
        {
            var user = await GetCurrentUserAsync();
            if (user != null)
            {
                List<ReactObject> lista = TempObject.GetTempData();
                List<ProjectHeadersModel> headerList = new List<ProjectHeadersModel>();
                List<ProjectTextModel> textList = new List<ProjectTextModel>();
                List<ProjectImageModel> imageList = new List<ProjectImageModel>();
                foreach (var item in lista)
                {
                    ProjectHeadersModel newHeader = CreateHeader(item.Header, _db);
                    ProjectTextModel newText = CreateText(item.Text, _db);
                    //ProjectImageModel newImag = await CreateImageAsync(item.File, _db);
                    headerList.Add(newHeader);
                    textList.Add(newText);
                    //imageList.Add(newImag);
                }
                ProjectContentModel newContent = CreateContent(headerList, textList, imageList, _db);
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



        ///project/data
        [Route("project/data")]
        [HttpPost]
        public  IActionResult AddTempData(ReactObject data)
        {
            TempObject.AddToTemp(data);
            return Content("Success :)");
        }
        private ProjectContentModel CreateContent(List<ProjectHeadersModel> headerList, List<ProjectTextModel> textList, List<ProjectImageModel> imageList, ApplicationDbContext db)
        {
            ProjectContentModel tempContent = new ProjectContentModel()
            {
                Headers = headerList,
                Texts = textList,
                WorkImages = imageList
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

    }

}

