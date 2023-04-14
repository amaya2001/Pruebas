using Microsoft.AspNetCore.Mvc;

using CRUD_CORE.Datos;
using CRUD_CORE.Models;
using Rotativa.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using CRUD_CORE.Permisos;
using System.Text.RegularExpressions;

namespace CRUD_CORE.Controllers
{
   // [Authorize]
    public class MantenedorController : Controller
    {
        VentaDatos _VentaDatos = new VentaDatos();
        public IActionResult Listar()
        {
            // La vista mostrara una lista de contactos
            var oLista = _VentaDatos.Listar();
            return View(oLista);
        }
        //[PermisosRol(Roles.Administrador)]
       //[Authorize(Usuario.idRol = 1)]
        public IActionResult ListarDia() {
            var oLista = _VentaDatos.ListarDia();
            return View(oLista);
        }

        public IActionResult Guardar()
        {
            // Metodo solo devuelve la vista

            return View();
        }
        [HttpPost]
        public IActionResult Guardar(VentaModel oVenta)
        {
            // Metodo recibe el objeto para guardarlo en BD
            if (!ModelState.IsValid)
                return View();

            string nombre = new string(oVenta.Nombre.ToString());

            if (nombre.Length < 3 || nombre.Length > 31)
            {
                ViewData["Mensaje"] = "El nombre debe minimo 3 caracteres y maximo 30";
                return View();
            }

            if (nombre.Any(char.IsUpper))
            {
                ViewData["Mensaje"] = "El nombre no debe contener letras mayúsculas";
                return View();
            }

            if (oVenta.Precio < 20000 || oVenta.Precio > 2000000)
            {
                ViewData["Mensaje"] = "El precio debe estar entre 20.000 y 2.000.000";
                return View();
            }
            


            var respuesta = _VentaDatos.Guardar(oVenta);
            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

        public IActionResult Eliminar(int idVenta)
        {
            var oventa= _VentaDatos.Obtener(idVenta);
            return View(oventa);
        }


            [HttpPost]
        public IActionResult Eliminar(VentaModel oVenta)
        {
            var rpt = _VentaDatos.Eliminar(oVenta.idVenta);
            if (rpt)
                return RedirectToAction("Listar");
            else
                return View();
        
        }
        public IActionResult Editar(int idVenta)
        {
            var oventa = _VentaDatos.Obtener(idVenta);
            return View(oventa);
        }


        [HttpPost]
        public IActionResult Editar(VentaModel oVenta)
        {
            var rpt = _VentaDatos.Editar(oVenta);
            if (rpt)
                return RedirectToAction("Listar");
            else
                return View();

        }

        public IActionResult Generarpdf()
        {
            _VentaDatos.GenerarPDF();
            return RedirectToAction("Listar");
        }


    }
}
