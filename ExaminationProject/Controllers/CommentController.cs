using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ExaminationProject.Models.ProjektModels;
using Microsoft.AspNetCore.Identity;
using ExaminationProject.Models;
using ExaminationProject.Data;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ExaminationProject.Controllers
{
    [Authorize]
    public class CommentController : Controller
    {
        private static IList<ProjectCommentModel> _comments;
        private ApplicationDbContext _db;
        private UserManager<ApplicationUser> _userManager;

        public CommentController(UserManager<ApplicationUser> userManager, ApplicationDbContext db)
        {
            _db = db;
            _userManager = userManager;
            _comments = new List<ProjectCommentModel>
            {
                new ProjectCommentModel
                {
                    Id = _comments.Count+1,
                    Author = "Mike",
                    Text = "Detta är bara test data",
                    TimeStamp = DateTime.Now
                },
            };
        }
        // GET: /<controller>/
        public IActionResult Index()
        {        
            return View();
        }
        [Route("comments")]
        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Comments()
        {
            return Json(_comments);
        }
        [Route("comments/new")]
        [HttpPost]
        public IActionResult AddComment(ProjectCommentModel comment)
        {
            // Create a fake ID for this comment
            comment.Id = DateTime.Now.Minute;
            //comment.Author = _userManager.GetUserName(User);
            //comment.TimeStamp = DateTime.Now;
            _comments.Add(comment);
            return Content("Success :)");
        }
    }
}
