using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EjemploUsoSessionYAjax.Models;
using AutoMapper;

namespace EjemploUsoSessionYAjax.Controllers
{
    public class PruebaController : Controller
    {

        private List<Models.Item> Items
        {
            get
            {
                if(System.Web.HttpContext.Current.Session["LISTA"] == null)
                {
                    System.Web.HttpContext.Current.Session.Add("LISTA", new List<Item>());
                }
                return  (List<Item>) System.Web.HttpContext.Current.Session["LISTA"];
            }
        }

        // GET: Prueba
        public ActionResult Index()
        {
            Models.Employee employee = new Models.Employee
            {
                Id = 1,
                Nombre = "Jon",
                Apellido = "Doe",
                SalarioBruto = 1200,
                Activo = true                
            };

            ViewBag.Items = ObtenerItems();

            MapperConfiguration configuracionDeMapeo = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Models.Employee, ViewModels.EmployeeViewModel>();
            });

            var mapeadorDeObjetos = configuracionDeMapeo.CreateMapper();
            ViewBag.Employee = mapeadorDeObjetos.Map<Models.Employee, ViewModels.EmployeeViewModel>(employee);

            return View();
        }

        [HttpPost]  
        public ActionResult Finalizar()
        {
            List<Item> itemsGuardados = Items;
            return RedirectToAction("Index","Home");
        }

        [HttpPost]
        public JsonResult ListarItems()
        {
            return Json(Items);
        }

        [HttpPost]
        public void GuardarItem(int id, string nombre)
        {
            Models.Item item = new Models.Item() ;
            item.Id = id;
            item.Nombre = nombre;

            Items.Add(item);
        }

        private List<Item> ObtenerItems()
        {
            List<Item> listaInicial = new List<Item>();

            for (int i = 0; i < 10; i++)
            {
                Item item = new Item
                {
                    Id = i,
                    Nombre = "Item_" + i.ToString()
                };
                listaInicial.Add(item);
            }

            return listaInicial;
        }
    }
}