using ASP.NET_SIMS.Models;
using ASP.NET_SIMS.Repositories;
using ASP.NET_SIMS.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIMS.Models;

namespace ASP.NET_SIMS.Controllers
{
    [Authorize(Roles = "Faculty")]
    public class FacultyController : Controller
    {
        private readonly IGradeService _gradeService;

        public FacultyController(IGradeService gradeService)
        {
            _gradeService = gradeService;
        }
      
        public IActionResult AssignGrade(int enrollmentID, int facultyID, double score)
        {
            _gradeService.AssignGrade(enrollmentID, facultyID, score);
            return Ok("Grade Assigned Successfully");
        }
        [HttpGet]
        public IActionResult AssignGrade()
        {
            return View(new AssignGradeViewModel());
        }

     
    }



}
