using CRUD_CORE.Models;
using CRUD_CORE.Datos;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CRUD_CORE.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Usuarios()
        {
            return View();
        }

        public IActionResult Administrador()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult CerrarSesion()
        {
            return RedirectToAction("Login", "Accesos");
        }

        public IActionResult SinPermiso()
        {
            ViewBag.Message = "Usted no cuenta con el permiso para ver esta pagina";
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}