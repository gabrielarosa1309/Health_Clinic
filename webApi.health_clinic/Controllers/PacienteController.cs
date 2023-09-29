using Microsoft.AspNetCore.Mvc;

namespace webApi.health_clinic.Controllers
{
    public class PacienteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
