using Microsoft.AspNetCore.Mvc;

namespace ST.Controllers
{
    public class SolutionController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Current = "Solution";
            
            return View();
        }
    }
}