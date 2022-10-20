using Microsoft.AspNetCore.Mvc;

namespace GestionCEGEP.Controllers
{
    public class CegepController : Controller
    {
        // 
        // GET: /Cegep/

        public IActionResult Index()
        {
            return View();
        }

        // 
        // GET: /Cegep/Welcome/ 

        public string Welcome()
        {
            return "This is the Welcome action method...";
        }
    }
}
