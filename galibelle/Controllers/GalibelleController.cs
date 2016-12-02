using galibelle.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace galibelle.Controllers
{
    public class GalibelleController : Controller
    {
        // GET: Prueba
        public ActionResult Index()
        {
        
            return View();
        }
        // GET: Prueba
        public ActionResult ListaSucursales()
        {

            return View();
        }
        // GET: Prueba
        public ActionResult PedidosSucursal()
        {

            return View();
        }
        // GET: Prueba
        public ActionResult StockSucursal()
        {

            return View();
        }
        // GET: Prueba
        public ActionResult Straps()
        {

            return View();
        }

        public ActionResult Login() {
            return View();
        }

    }
}
