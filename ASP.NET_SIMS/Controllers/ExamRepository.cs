using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_SIMS.Controllers
{
    public class ExamRepository : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
