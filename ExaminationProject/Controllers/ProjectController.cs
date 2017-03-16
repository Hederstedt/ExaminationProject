using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ExaminationProject.Models;
using ExaminationProject.Data;
using Microsoft.AspNetCore.Identity;
using ExaminationProject.Models.ProjektModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ExaminationProject.Controllers
{
    public class ProjectController : Controller
    {      
        private ApplicationDbContext _db;
        private UserManager<ApplicationUser> _userManager;

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

        ///project/data
        [Route("project/data")]
        [HttpPost]
        public IActionResult AddProject(ProjectContentModel data)
        {

            return Content("Success :)");
        }
    }
}
