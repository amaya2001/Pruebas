using System.Web.Mvc;

namespace CRUD_CORE.test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethodLoginValido()
        {
            var controladorlogin = new CRUD_CORE.Controllers.AccesosController();
            var usuario = new CRUD_CORE.Models.Usuario { Nombre = 22, Clave = "22" };
            var result = controladorlogin.Login(usuario);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestMethodLoginInvalido()
        {
            var controladorlogin = new CRUD_CORE.Controllers.AccesosController();
            var usuario = new CRUD_CORE.Models.Usuario{ Nombre = 22, Clave = "21112" };
            var result = controladorlogin.Login(usuario);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestMethodAgregarVentaValido()
        {
            var controladorventa = new CRUD_CORE.Controllers.MantenedorController();
            var venta = new CRUD_CORE.Models.VentaModel { Nombre = "Leche", Precio = 20000, DiaVenta = Convert.ToDateTime( "24/05/2023" )};
            var result = controladorventa.Guardar(venta);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestMethodAgregarVentaInvalido()
        {
            var controladorventa = new CRUD_CORE.Controllers.MantenedorController();
            var venta = new CRUD_CORE.Models.VentaModel { Nombre = "Leche", Precio = 500, DiaVenta = Convert.ToDateTime("24/05/2023") };
            var result = controladorventa.Guardar(venta);
            Assert.IsNotNull(result);
            Console.WriteLine(result);
        }

        [TestMethod]
        public void TestMethodRegistrarUsuarioValido()
        {
            var controladorregistro = new CRUD_CORE.Controllers.AccesosController();
            var usuario = new CRUD_CORE.Models.Usuario { Nombre = 123455, Correo = "amaya@gmail.com", Clave = "Contrasena1234!", ConfirmarClave = "Contrasena1234!" };
            var result = controladorregistro.Registro(usuario);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestMethodRegistrarUsuarioInvalido()
        {
            var controladorregistro = new CRUD_CORE.Controllers.AccesosController();
            var usuario = new CRUD_CORE.Models.Usuario { Nombre = 11, Correo = "amayagmail.com", Clave = "Contrasena", ConfirmarClave = "Contrasena12" };
            var result = controladorregistro.Registro(usuario);
            Assert.IsNotNull(result);
        }





    }
}