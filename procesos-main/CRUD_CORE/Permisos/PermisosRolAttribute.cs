using System.Web.Mvc;
using CRUD_CORE.Models;
using System.Web;

namespace CRUD_CORE.Permisos
{
    public class PermisosRolAttribute: ActionFilterAttribute
    {
        private Roles idrol;

        public PermisosRolAttribute(Roles _idrol) {

            idrol = _idrol;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
           // if (usuario.idRol != this.idrol) {
                // filterContext.Result = new RedirectResult("~/Home/SinPermiso");
           // }
        }
    }
}
