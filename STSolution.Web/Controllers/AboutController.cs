using Microsoft.AspNetCore.Mvc;

namespace ST.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Current = "About";
            
            return View();
        }
    }
}