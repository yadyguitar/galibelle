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
      
        public ActionResult Index()
        {
            if (Session["LogedUserID"] == null){return RedirectToAction("Login");}
            return View();
        }
        public ActionResult Estadisticas()
        {
            if (Session["LogedUserID"] == null) { return RedirectToAction("Login"); }
            return View();
        }

        public ActionResult ListaSucursales()
        {
            if (Session["LogedUserID"] == null) { return RedirectToAction("Login"); }
            return View();
        }
       
        public ActionResult PedidosSucursal()
        {
            if (Session["LogedUserID"] == null) { return RedirectToAction("Login"); }
            return View();
        }
        public ActionResult VentasSucursal()
        {
            if (Session["LogedUserID"] == null) { return RedirectToAction("Login"); }
            return View();
        }
        public ActionResult EstadisticasSucursal()
        {
            if (Session["LogedUserID"] == null) { return RedirectToAction("Login"); }
            return View();
        }

        public ActionResult StockSucursal()
        {

            if (Session["LogedUserID"] == null) { return RedirectToAction("Login"); }
            return View();
        }
      
        public ActionResult Straps()
        {
            if (Session["LogedUserID"] == null) { return RedirectToAction("Login"); }
            var lista = from x in Utils.GalibelleContext.Colores select x;
            return View(lista);
        }
        public ActionResult Suelas()
        {
            if (Session["LogedUserID"] == null) { return RedirectToAction("Login"); }
            var lista = from x in Utils.GalibelleContext.Colores select x;
            return View(lista);
        }

        public ActionResult Login() {
            Session.Clear();
            Session.RemoveAll();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Usuarios u) {
            if (ModelState.IsValid) {
                var db = Utils.GalibelleContext;
                var v = db.Usuarios.Where(a => a.usuario.Equals(u.usuario) && a.password.Equals(u.password)).FirstOrDefault();
                if (v != null) {
                    Session["LogedUserID"] = v.IdUsuario.ToString();
                    Session["LogedUserName"] = v.usuario.ToString();
                    return RedirectToAction("Index");
                }
            }
            return View(u);
        }

    }
}
