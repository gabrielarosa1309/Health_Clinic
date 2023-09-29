using Microsoft.AspNetCore.Mvc;

namespace webApi.health_clinic.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
