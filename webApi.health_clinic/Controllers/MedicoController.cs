using Microsoft.AspNetCore.Mvc;

namespace webApi.health_clinic.Controllers
{
    public class MedicoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
