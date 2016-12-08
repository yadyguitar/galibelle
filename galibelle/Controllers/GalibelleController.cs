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
           // if (Session["LogedUserID"] == null) { return RedirectToAction("Login"); }
            var lista = from sto in Utils.GalibelleContext.Stock_straps
                        join str in Utils.GalibelleContext.Straps on sto.IdStraps equals str.IdStraps
                        join mod in Utils.GalibelleContext.Modelos on str.IdModelos equals mod.IdModelos
                        join tip in Utils.GalibelleContext.Tipo_strap on sto.IdTipo_strap equals tip.IdTipo_strap
                        join col in Utils.GalibelleContext.Colores on tip.IdColores equals col.IdColores
                        join text in Utils.GalibelleContext.Textura on tip.IdTextura equals text.IdTextura
                       
                        select new MyViewModel { Stock_straps = sto, Straps=str, Modelos=mod , Colores=col, Textura=text, Tipo_strap=tip };

            /*
            try
            {
                var db = Utils.GalibelleContext;
                db.Stock_straps.Add(new Stock_straps() { IdStraps = (from str in Utils.GalibelleContext.Straps where str.codigo_strap=="GB01" select str.IdStraps).First(),
                                                          IdTipo_strap = (from tip in Utils.GalibelleContext.Tipo_strap where tip.IdColores==2 && tip.IdTextura==1 select tip.IdTipo_strap ).First(),
                                                            IdSucursales=1,
                                                            size_strap="L",
                                                            cantidad=8,
                                                            temporada=2015});

                //db.SaveChangesAsync();
                //db.SaveChanges();
            }
            catch
            {
                System.Diagnostics.Debug.WriteLine("error");
            }
            */
            ViewBag.MyViewModel = lista;
            return View();
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
                    Session["IdSucursal"] = v.IdSucursales.ToString();
                    return RedirectToAction("Index");
                }
            }
            return View(u);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult guardaStrap(MyViewModel v)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var db = Utils.GalibelleContext;
                    int idcol = (from col in Utils.GalibelleContext.Colores where col.nombre_color == v.Colores.nombre_color select col.IdColores).First();
                    int idtext = (from tx in Utils.GalibelleContext.Textura where tx.nombre_Textura == v.Textura.nombre_Textura select tx.IdTextura).First();
                    db.Stock_straps.Add(new Stock_straps()
                    {
                        IdStraps = (from str in Utils.GalibelleContext.Straps where str.codigo_strap == v.Straps.codigo_strap select str.IdStraps).First(),
                        IdTipo_strap = (from tip in Utils.GalibelleContext.Tipo_strap where tip.IdColores == idcol && tip.IdTextura == idtext select tip.IdTipo_strap).First(),
                        IdSucursales = Convert.ToInt32(Session["IdSucursal"]),
                        size_strap = v.Stock_straps.size_strap.ToString(),
                        cantidad = v.Stock_straps.cantidad,
                        temporada = v.Stock_straps.temporada
                    });

                    //db.SaveChangesAsync();
                    db.SaveChanges();
                    return RedirectToAction("Straps");
                }
                catch
                {
                    try
                    {
                        var db = Utils.GalibelleContext;
                        
                        int idcol = (from col in Utils.GalibelleContext.Colores where col.nombre_color == v.Colores.nombre_color select col.IdColores).First();
                        int idtext = (from tx in Utils.GalibelleContext.Textura where tx.nombre_Textura == v.Textura.nombre_Textura select tx.IdTextura).First();
                        db.Tipo_strap.Add(new Tipo_strap { IdColores=idcol,IdTextura=idtext});
                        db.SaveChanges();
                        db.Stock_straps.Add(new Stock_straps()
                        {
                            IdStraps = (from str in Utils.GalibelleContext.Straps where str.codigo_strap == v.Straps.codigo_strap select str.IdStraps).First(),
                            IdTipo_strap = (from tip in Utils.GalibelleContext.Tipo_strap where tip.IdColores == idcol && tip.IdTextura == idtext select tip.IdTipo_strap).First(),
                            IdSucursales = Convert.ToInt32(Session["IdSucursal"]),
                            size_strap = v.Stock_straps.size_strap.ToString(),
                            cantidad = v.Stock_straps.cantidad,
                            temporada = v.Stock_straps.temporada
                        });

                        //db.SaveChangesAsync();
                        db.SaveChanges();
                        return RedirectToAction("Straps");
                    }
                    catch {

                    }
                }
            }
            return View();
        }

    }
}
