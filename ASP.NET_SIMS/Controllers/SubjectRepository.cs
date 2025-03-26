using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_SIMS.Controllers
{
    public class SubjectRepository : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
