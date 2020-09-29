using Microsoft.AspNetCore.Mvc;

namespace ST.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Current = "Contact";
            
            return View();
        }
    }
}