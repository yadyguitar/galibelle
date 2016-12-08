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
            if (Session["LogedUserID"] == null) { return RedirectToAction("Login"); }
            else if (Session["LogedUserID"].Equals("1"))
            {
                Session["menu"] = 4;
                return View();
            }

            else
                return RedirectToAction("Sucursal");

        }
        public ActionResult Estadisticas()
        {
            if (Session["LogedUserID"] == null) { return RedirectToAction("Login"); }
            else if (Session["LogedUserID"].Equals("1"))
            {
                Session["menu"] = 7;
                return View();
            }
            else
                return RedirectToAction("Sucursal");
        }

        public ActionResult ListaSucursales()
        {
            if (Session["LogedUserID"] == null) { return RedirectToAction("Login"); }
            else if (Session["LogedUserID"].Equals("1"))
            {
                Session["menu"] = 6;
                return View();
            }
            else
                return RedirectToAction("Sucursal");
        }
       
        public ActionResult PedidosSucursal()
        {
            if (Session["LogedUserID"] == null) { return RedirectToAction("Login"); }
            else if (Session["LogedUserID"].Equals("1"))
            {
                Session["menu"] = 6;
                return View();
            }
            else
                return RedirectToAction("Sucursal");
        }
        public ActionResult VentasSucursal()
        {
            if (Session["LogedUserID"] == null) { return RedirectToAction("Login"); }
            else if (Session["LogedUserID"].Equals("1"))
            {
                Session["menu"] = 6;
                return View();
            }
            else
                return RedirectToAction("Sucursal");
        }
        public ActionResult EstadisticasSucursal()
        {
            if (Session["LogedUserID"] == null) { return RedirectToAction("Login"); }
            else if (Session["LogedUserID"].Equals("1"))
            {
                Session["menu"] = 6;
                return View();
            }
            else
                return RedirectToAction("Sucursal");
        }

        public ActionResult StockSucursal()
        {

            if (Session["LogedUserID"] == null) { return RedirectToAction("Login"); }
            else if (Session["LogedUserID"].Equals("1"))
            {
                Session["menu"] = 6;
                return View();
            }
            else
                return RedirectToAction("Sucursal");
        }

        public ActionResult Straps()
        {

            if (Session["LogedUserID"] == null) { return RedirectToAction("Login"); }
            else if (Session["LogedUserID"].Equals("1")) {
                Session["menu"] = 5;
                var lista = from sto in Utils.GalibelleContext.Stock_straps
                            join str in Utils.GalibelleContext.Straps on sto.IdStraps equals str.IdStraps
                            join mod in Utils.GalibelleContext.Modelos on str.IdModelos equals mod.IdModelos
                            join tip in Utils.GalibelleContext.Tipo_strap on sto.IdTipo_strap equals tip.IdTipo_strap
                            join col in Utils.GalibelleContext.Colores on tip.IdColores equals col.IdColores
                            join text in Utils.GalibelleContext.Textura on tip.IdTextura equals text.IdTextura
                            select new MyViewModel { Stock_straps = sto, Straps = str, Modelos = mod, Colores = col, Textura = text, Tipo_strap = tip };
                ViewBag.MyViewModel=lista;
                return View();
            }
            else
                return RedirectToAction("Sucursal");

        }
        public ActionResult Suelas()
        {
            if (Session["LogedUserID"] == null) { return RedirectToAction("Login"); }
            else if (Session["LogedUserID"].Equals("1"))
            {
                Session["menu"] = 5;
                var lista = from x in Utils.GalibelleContext.Colores select x;
                return View(lista);
            }
            else
                return RedirectToAction("Sucursal");
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
                    if (v.IdUsuario.ToString().Equals("1"))
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        return RedirectToAction("Sucursal");
                    }

                    


                }
            }
            return View(u);
        }


        public ActionResult Sucursal()
        {
            if (Session["LogedUserID"] == null) { return RedirectToAction("Login"); }
            else if (Session["LogedUserID"].Equals("1") == false)
            {
                Session["menu"] = 1;
                var lista = from x in Utils.GalibelleContext.Colores select x;
                return View(lista);
            }
            
            else
                return RedirectToAction("Index");

        }

        
        public ActionResult PedidosSuc()
        {
            if (Session["LogedUserID"] == null) { return RedirectToAction("Login"); }
            else if (Session["LogedUserID"].Equals("1") == false)
            {
                Session["menu"] = 3;
                var lista = from x in Utils.GalibelleContext.Colores select x;
                return View(lista);
            }

            else
                return RedirectToAction("Index");

        }

       
        public ActionResult VentasSuc()
        {
            if (Session["LogedUserID"] == null) { return RedirectToAction("Login"); }
            else if (Session["LogedUserID"].Equals("1") == false)
            {
                Session["menu"] = 1;
                var lista = from x in Utils.GalibelleContext.Colores select x;
                return View(lista);
            }

            else
                return RedirectToAction("Index");
        }

        public ActionResult StockExterior()
        {
            if (Session["LogedUserID"] == null) { return RedirectToAction("Login"); }
            else if (Session["LogedUserID"].Equals("1") == false)
            {
                Session["menu"] = 2;
                var lista = from x in Utils.GalibelleContext.Colores select x;
                return View(lista);
            }

            else
                return RedirectToAction("Index");
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
