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
       
        public ActionResult StockSucursal()
        {

            if (Session["LogedUserID"] == null) { return RedirectToAction("Login"); }
            return View();
        }
      
        public ActionResult Straps()
        {
            if (Session["LogedUserID"] == null) { return RedirectToAction("Login"); }
            var lista = from sto in Utils.GalibelleContext.Stock_straps
                        join str in Utils.GalibelleContext.Straps on sto.IdStraps equals str.IdStraps
                        join mod in Utils.GalibelleContext.Modelos on str.IdModelos equals mod.IdModelos
                        join tip in Utils.GalibelleContext.Tipo_strap on sto.IdTipo_strap equals tip.IdTipo_strap
                        join col in Utils.GalibelleContext.Colores on tip.IdColores equals col.IdColores
                        join text in Utils.GalibelleContext.Textura on tip.IdTextura equals text.IdTextura 
                        select new MyViewModel { Stock_straps = sto, Straps=str, Modelos=mod , Colores=col, Textura=text, Tipo_strap=tip };
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
