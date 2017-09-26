using EjemploUsoSessionYAjax.Core;
using System.Web.Mvc;

namespace EjemploUsoSessionYAjax.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProveedorDeMensaje proveedorDeMensaje;

        public HomeController(IProveedorDeMensaje proveedorDeMensaje)
        {
            this.proveedorDeMensaje = proveedorDeMensaje;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = this.proveedorDeMensaje.ObtenerMensaje();

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}