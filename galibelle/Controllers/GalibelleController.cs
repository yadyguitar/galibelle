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
                var lista = from usu in Utils.GalibelleContext.Usuarios
                            join suc in Utils.GalibelleContext.Sucursales on usu.IdSucursales equals suc.IdSucursales
                            where usu.IdUsuario != 1
                            select new MyViewModel { Usuarios = usu, Sucursales = suc };
                ViewBag.MyViewModel = lista;
                return View();
            }
            else
                return RedirectToAction("Sucursal");
        }
       
        public ActionResult PedidosSucursal(int i)
        {
            if (Session["LogedUserID"] == null) { return RedirectToAction("Login"); }
            else if (Session["LogedUserID"].Equals("1"))
            {
                Session["menu"] = 6;
                var lista = from sto in Utils.GalibelleContext.Stock_suelas
                            join sue in Utils.GalibelleContext.Suelas on sto.IdSuelas equals sue.IdSuelas
                            join mod in Utils.GalibelleContext.Modelos on sue.IdModelos equals mod.IdModelos
                            where sto.IdSucursales == i
                            select new MyViewModel { Stock_suelas = sto, Suelas = sue, Modelos = mod };
                ViewBag.MyViewModel = lista;

                var lista2 = from sto in Utils.GalibelleContext.Stock_straps
                             join str in Utils.GalibelleContext.Straps on sto.IdStraps equals str.IdStraps
                             join mod in Utils.GalibelleContext.Modelos on str.IdModelos equals mod.IdModelos
                             join tip in Utils.GalibelleContext.Tipo_strap on sto.IdTipo_strap equals tip.IdTipo_strap
                             join col in Utils.GalibelleContext.Colores on tip.IdColores equals col.IdColores
                             join text in Utils.GalibelleContext.Textura on tip.IdTextura equals text.IdTextura
                             where sto.IdSucursales == i
                             select new MyViewModel { Stock_straps = sto, Straps = str, Modelos = mod, Colores = col, Textura = text, Tipo_strap = tip };


                ViewBag.MyViewModel2 = lista2;
                return View();
            }
            else
                return RedirectToAction("Sucursal");
        }
        public ActionResult VentasSucursal(int i)
        {
            if (Session["LogedUserID"] == null) { return RedirectToAction("Login"); }
            else if (Session["LogedUserID"].Equals("1"))
            {
                Session["menu"] = 6;
                var lista = from sto in Utils.GalibelleContext.Stock_suelas
                            join sue in Utils.GalibelleContext.Suelas on sto.IdSuelas equals sue.IdSuelas
                            join mod in Utils.GalibelleContext.Modelos on sue.IdModelos equals mod.IdModelos
                            where sto.IdSucursales == i
                            select new MyViewModel { Stock_suelas = sto, Suelas = sue, Modelos = mod };
                ViewBag.MyViewModel = lista;

                var lista2 = from sto in Utils.GalibelleContext.Stock_straps
                             join str in Utils.GalibelleContext.Straps on sto.IdStraps equals str.IdStraps
                             join mod in Utils.GalibelleContext.Modelos on str.IdModelos equals mod.IdModelos
                             join tip in Utils.GalibelleContext.Tipo_strap on sto.IdTipo_strap equals tip.IdTipo_strap
                             join col in Utils.GalibelleContext.Colores on tip.IdColores equals col.IdColores
                             join text in Utils.GalibelleContext.Textura on tip.IdTextura equals text.IdTextura
                             where sto.IdSucursales == i
                             select new MyViewModel { Stock_straps = sto, Straps = str, Modelos = mod, Colores = col, Textura = text, Tipo_strap = tip };


                ViewBag.MyViewModel2 = lista2;
                return View();
            }
            else
                return RedirectToAction("Sucursal");
        }
        public ActionResult EstadisticasSucursal(int i)
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

        public ActionResult StockSucursal(int i)
        {

            if (Session["LogedUserID"] == null) { return RedirectToAction("Login"); }
            else if (Session["LogedUserID"].Equals("1"))
            {
                System.Diagnostics.Debug.WriteLine(i);
                Session["menu"] = 6;
                var lista = from sto in Utils.GalibelleContext.Stock_suelas
                            join sue in Utils.GalibelleContext.Suelas on sto.IdSuelas equals sue.IdSuelas
                            join mod in Utils.GalibelleContext.Modelos on sue.IdModelos equals mod.IdModelos
                            where sto.IdSucursales==i
                            select new MyViewModel { Stock_suelas = sto, Suelas = sue, Modelos = mod };
                ViewBag.MyViewModel = lista;

                var lista2 = from sto in Utils.GalibelleContext.Stock_straps
                             join str in Utils.GalibelleContext.Straps on sto.IdStraps equals str.IdStraps
                             join mod in Utils.GalibelleContext.Modelos on str.IdModelos equals mod.IdModelos
                             join tip in Utils.GalibelleContext.Tipo_strap on sto.IdTipo_strap equals tip.IdTipo_strap
                             join col in Utils.GalibelleContext.Colores on tip.IdColores equals col.IdColores
                             join text in Utils.GalibelleContext.Textura on tip.IdTextura equals text.IdTextura
                             where sto.IdSucursales == i
                             select new MyViewModel { Stock_straps = sto, Straps = str, Modelos = mod, Colores = col, Textura = text, Tipo_strap = tip };


                ViewBag.MyViewModel2 = lista2;
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
                            where sto.IdSucursales==1
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

                var lista = from sto in Utils.GalibelleContext.Stock_suelas
                            join sue in Utils.GalibelleContext.Suelas on sto.IdSuelas equals sue.IdSuelas
                            join mod in Utils.GalibelleContext.Modelos on sue.IdModelos equals mod.IdModelos
                            where sto.IdSucursales==1
                            select new MyViewModel { Stock_suelas = sto, Suelas = sue, Modelos = mod};
                ViewBag.MyViewModel = lista;
                return View();


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
            return Content("<script language='javascript' type='text/javascript'>alert('Oh oh... Usuario o contraseña incorrecta. Intente de nuevo'); window.location='Login'</script>");
        }

        public ActionResult Sucursal()
        {
            if (Session["LogedUserID"] == null) { return RedirectToAction("Login"); }
            else if (Session["LogedUserID"].Equals("1") == false)
            {
                Session["menu"] = 1;
                int idsuc = Convert.ToInt32(Session["IdSucursal"]);
                var lista = from sto in Utils.GalibelleContext.Stock_suelas
                            join sue in Utils.GalibelleContext.Suelas on sto.IdSuelas equals sue.IdSuelas
                            join mod in Utils.GalibelleContext.Modelos on sue.IdModelos equals mod.IdModelos
                            where (sto.IdSucursales == idsuc)
                            select new MyViewModel { Stock_suelas = sto, Suelas = sue, Modelos = mod };
                ViewBag.MyViewModel = lista;

                var lista2 = from sto in Utils.GalibelleContext.Stock_straps
                            join str in Utils.GalibelleContext.Straps on sto.IdStraps equals str.IdStraps
                            join mod in Utils.GalibelleContext.Modelos on str.IdModelos equals mod.IdModelos
                            join tip in Utils.GalibelleContext.Tipo_strap on sto.IdTipo_strap equals tip.IdTipo_strap
                            join col in Utils.GalibelleContext.Colores on tip.IdColores equals col.IdColores
                            join text in Utils.GalibelleContext.Textura on tip.IdTextura equals text.IdTextura
                            where (sto.IdSucursales == idsuc)
                            select new MyViewModel { Stock_straps = sto, Straps = str, Modelos = mod, Colores = col, Textura = text, Tipo_strap = tip };
                
                
                ViewBag.MyViewModel2 = lista2;
                return View();
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
                var lista = from sto in Utils.GalibelleContext.Stock_suelas
                            join sue in Utils.GalibelleContext.Suelas on sto.IdSuelas equals sue.IdSuelas
                            join mod in Utils.GalibelleContext.Modelos on sue.IdModelos equals mod.IdModelos
                            select new MyViewModel { Stock_suelas = sto, Suelas = sue, Modelos = mod };
                ViewBag.MyViewModel = lista;

                var lista2 = from sto in Utils.GalibelleContext.Stock_straps
                             join str in Utils.GalibelleContext.Straps on sto.IdStraps equals str.IdStraps
                             join mod in Utils.GalibelleContext.Modelos on str.IdModelos equals mod.IdModelos
                             join tip in Utils.GalibelleContext.Tipo_strap on sto.IdTipo_strap equals tip.IdTipo_strap
                             join col in Utils.GalibelleContext.Colores on tip.IdColores equals col.IdColores
                             join text in Utils.GalibelleContext.Textura on tip.IdTextura equals text.IdTextura
                             select new MyViewModel { Stock_straps = sto, Straps = str, Modelos = mod, Colores = col, Textura = text, Tipo_strap = tip };


                ViewBag.MyViewModel2 = lista2;
                return View();
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
        public ActionResult StockExteriorSuelas()
        {
            if (Session["LogedUserID"] == null) { return RedirectToAction("Login"); }
            else if (Session["LogedUserID"].Equals("1") == false)
            {
                int idsuc = Convert.ToInt32(Session["IdSucursal"]);
                Session["menu"] = 2;
                var lista = from sto in Utils.GalibelleContext.Stock_suelas
                            join sue in Utils.GalibelleContext.Suelas on sto.IdSuelas equals sue.IdSuelas
                            join mod in Utils.GalibelleContext.Modelos on sue.IdModelos equals mod.IdModelos
                            join suc in Utils.GalibelleContext.Sucursales on sto.IdSucursales equals suc.IdSucursales
                            where (sto.IdSucursales != idsuc)
                            select new MyViewModel { Stock_suelas = sto, Suelas = sue, Modelos = mod, Sucursales = suc};
                ViewBag.MyViewModel = lista;
                return View();
            }

            else
                return RedirectToAction("Index");
        }

        public ActionResult StockExteriorStraps()
        {
            if (Session["LogedUserID"] == null) { return RedirectToAction("Login"); }
            else if (Session["LogedUserID"].Equals("1") == false)
            {
                int idsuc = Convert.ToInt32(Session["IdSucursal"]);
                Session["menu"] = 2;
                var lista = from sto in Utils.GalibelleContext.Stock_straps
                            join str in Utils.GalibelleContext.Straps on sto.IdStraps equals str.IdStraps
                            join mod in Utils.GalibelleContext.Modelos on str.IdModelos equals mod.IdModelos
                            join tip in Utils.GalibelleContext.Tipo_strap on sto.IdTipo_strap equals tip.IdTipo_strap
                            join col in Utils.GalibelleContext.Colores on tip.IdColores equals col.IdColores
                            join text in Utils.GalibelleContext.Textura on tip.IdTextura equals text.IdTextura
                            join suc in Utils.GalibelleContext.Sucursales on sto.IdSucursales equals suc.IdSucursales
                            where (sto.IdSucursales != idsuc)
                            select new MyViewModel { Stock_straps = sto, Straps = str, Modelos = mod, Colores = col, Textura = text, Tipo_strap = tip , Sucursales = suc};
                ViewBag.MyViewModel = lista;
                return View();
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
                    //Primer caso, que se encuentre tipo_strap y straps, registrados
                    var db = Utils.GalibelleContext;
                    int idcol = (from col in Utils.GalibelleContext.Colores where col.nombre_color == v.Colores.nombre_color select col.IdColores).First();
                    int idtext = (from tx in Utils.GalibelleContext.Textura where tx.nombre_Textura == v.Textura.nombre_Textura select tx.IdTextura).First();

                    int prueba = (from tip in Utils.GalibelleContext.Tipo_strap where tip.IdColores == idcol && tip.IdTextura == idtext select tip.IdTipo_strap).First();

                    System.Diagnostics.Debug.WriteLine(prueba);
                    db.Stock_straps.Add(new Stock_straps()
                    {
                        IdStraps = (from str in Utils.GalibelleContext.Straps where str.codigo_strap == v.Straps.codigo_strap select str.IdStraps).First(),
                        IdTipo_strap = (from tip in Utils.GalibelleContext.Tipo_strap where tip.IdColores == idcol && tip.IdTextura == idtext select tip.IdTipo_strap).First(),
                        IdSucursales = Convert.ToInt32(Session["IdSucursal"]),
                        size_strap = v.Stock_straps.size_strap.ToString(),
                        cantidad = v.Stock_straps.cantidad,
                        temporada = v.Stock_straps.temporada,
                        precio_strap_unitario = v.Stock_straps.precio_strap_unitario
                    });

                    //db.SaveChangesAsync();
                    db.SaveChanges();
                    return RedirectToAction("Straps");
                }
                catch
                {
                    //2do caso, que 
                    try
                    {
                        var db = Utils.GalibelleContext;
                        int idcol = (from col in Utils.GalibelleContext.Colores where col.nombre_color == v.Colores.nombre_color select col.IdColores).First();
                        int idtext = (from tx in Utils.GalibelleContext.Textura where tx.nombre_Textura == v.Textura.nombre_Textura select tx.IdTextura).First();

                        System.Diagnostics.Debug.WriteLine(idcol);
                        System.Diagnostics.Debug.WriteLine(idtext);


                        try { var temp = (from tip in Utils.GalibelleContext.Tipo_strap where tip.IdColores == idcol && tip.IdTextura == idtext select tip).First(); } catch {
                            db.Tipo_strap.Add(new Tipo_strap { IdColores = idcol, IdTextura = idtext });
                            db.SaveChanges();
                        }
                        try { var temp = (from str in Utils.GalibelleContext.Straps where str.codigo_strap == v.Straps.codigo_strap select str).First(); } catch {
                            int idmod = (from mod in Utils.GalibelleContext.Modelos where mod.nombre_modelo == v.Modelos.nombre_modelo select mod.IdModelos).First();
                            System.Diagnostics.Debug.WriteLine(idmod);
                            db.Straps.Add(new Straps { codigo_strap = v.Straps.codigo_strap, IdModelos = idmod });
                            db.SaveChanges();
                        }
                        
                        //db.Tipo_strap.Add(new Tipo_strap { IdColores=idcol,IdTextura=idtext});
                        //db.SaveChanges();
                        db.Stock_straps.Add(new Stock_straps()
                        {
                            IdStraps = (from str in Utils.GalibelleContext.Straps where str.codigo_strap == v.Straps.codigo_strap select str.IdStraps).First(),
                            IdTipo_strap = (from tip in Utils.GalibelleContext.Tipo_strap where tip.IdColores == idcol && tip.IdTextura == idtext select tip.IdTipo_strap).First(),
                            IdSucursales = Convert.ToInt32(Session["IdSucursal"]),
                            size_strap = v.Stock_straps.size_strap.ToString(),
                            cantidad = v.Stock_straps.cantidad,
                            temporada = v.Stock_straps.temporada,
                            precio_strap_unitario=v.Stock_straps.precio_strap_unitario
                        });

                        //db.SaveChangesAsync();
                        db.SaveChanges();
                        return RedirectToAction("Straps");
                    }
                    catch {
                        System.Diagnostics.Debug.WriteLine("error");
                    }
                }
            }
            return Content("<script language='javascript' type='text/javascript'>alert('Oh oh... Alguno de los datos importantes que ingresó no se encuentran en la base de datos. Intente de nuevo'); window.location='Straps'</script>");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult guardaSuela(MyViewModel v) {
            if (ModelState.IsValid)
            {
                try
                {
                    //Primer caso
                    var db = Utils.GalibelleContext;
                    int idmod=(from mod in Utils.GalibelleContext.Modelos where mod.nombre_modelo == v.Modelos.nombre_modelo select mod.IdModelos ).First();
                    
                    db.Stock_suelas.Add(new Stock_suelas()
                    {
                        IdSuelas = (from sue in Utils.GalibelleContext.Suelas where sue.nombre_suela == v.Suelas.nombre_suela && sue.IdModelos == idmod select sue.IdSuelas).First(),
                        talla_suela = v.Stock_suelas.talla_suela,
                        IdSucursales = Convert.ToInt32(Session["IdSucursal"]),
                        cantidad_suela = v.Stock_suelas.cantidad_suela,
                        temporada = v.Stock_suelas.temporada,
                        precio_suela_unitario = v.Stock_suelas.precio_suela_unitario
                    });

                    //db.SaveChangesAsync();
                    db.SaveChanges();
                    return RedirectToAction("Suelas");
                }
                catch
                {
                    //2do caso
                    try
                    {
                        var db = Utils.GalibelleContext;
                        
                        db.Suelas.Add(new Suelas { IdModelos = (from mod in Utils.GalibelleContext.Modelos where mod.nombre_modelo == v.Modelos.nombre_modelo select mod.IdModelos).First(),
                        nombre_suela = v.Suelas.nombre_suela});

                        db.SaveChanges();
                        int idmod = (from mod in Utils.GalibelleContext.Modelos where mod.nombre_modelo == v.Modelos.nombre_modelo select mod.IdModelos).First();
                        db.Stock_suelas.Add(new Stock_suelas()
                        {
                            IdSuelas = (from sue in Utils.GalibelleContext.Suelas where sue.nombre_suela == v.Suelas.nombre_suela && sue.IdModelos == idmod select sue.IdSuelas).First(),
                            talla_suela = v.Stock_suelas.talla_suela,
                            IdSucursales = Convert.ToInt32(Session["IdSucursal"]),
                            cantidad_suela = v.Stock_suelas.cantidad_suela,
                            temporada = v.Stock_suelas.temporada,
                            precio_suela_unitario = v.Stock_suelas.precio_suela_unitario
                        });
                        db.SaveChanges();
                        return RedirectToAction("Suelas");
                    }
                    catch
                    {
                        System.Diagnostics.Debug.WriteLine("error");
                    }
                }
            }
            return Content("<script language='javascript' type='text/javascript'>alert('Oh oh... Alguno de los datos importantes que ingresó no se encuentran en la base de datos. Intente de nuevo'); window.location='Suelas'</script>");
          //  return RedirectToAction("Error.cshtml");
        }

        public ActionResult VentaStrap(MyViewModel v)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //Primer caso
                    var db = Utils.GalibelleContext;
                    int idmod = (from mod in Utils.GalibelleContext.Modelos where mod.nombre_modelo == v.Modelos.nombre_modelo select mod.IdModelos).First();

                    db.Stock_suelas.Add(new Stock_suelas()
                    {
                        IdSuelas = (from sue in Utils.GalibelleContext.Suelas where sue.nombre_suela == v.Suelas.nombre_suela && sue.IdModelos == idmod select sue.IdSuelas).First(),
                        talla_suela = v.Stock_suelas.talla_suela,
                        IdSucursales = Convert.ToInt32(Session["IdSucursal"]),
                        cantidad_suela = v.Stock_suelas.cantidad_suela,
                        temporada = v.Stock_suelas.temporada,
                        precio_suela_unitario = v.Stock_suelas.precio_suela_unitario
                    });

                    //db.SaveChangesAsync();
                    db.SaveChanges();
                    return RedirectToAction("Suelas");
                }
                catch
                {
                    //2do caso
                    try
                    {
                        var db = Utils.GalibelleContext;

                        db.Suelas.Add(new Suelas
                        {
                            IdModelos = (from mod in Utils.GalibelleContext.Modelos where mod.nombre_modelo == v.Modelos.nombre_modelo select mod.IdModelos).First(),
                            nombre_suela = v.Suelas.nombre_suela
                        });

                        db.SaveChanges();
                        int idmod = (from mod in Utils.GalibelleContext.Modelos where mod.nombre_modelo == v.Modelos.nombre_modelo select mod.IdModelos).First();
                        db.Stock_suelas.Add(new Stock_suelas()
                        {
                            IdSuelas = (from sue in Utils.GalibelleContext.Suelas where sue.nombre_suela == v.Suelas.nombre_suela && sue.IdModelos == idmod select sue.IdSuelas).First(),
                            talla_suela = v.Stock_suelas.talla_suela,
                            IdSucursales = Convert.ToInt32(Session["IdSucursal"]),
                            cantidad_suela = v.Stock_suelas.cantidad_suela,
                            temporada = v.Stock_suelas.temporada,
                            precio_suela_unitario = v.Stock_suelas.precio_suela_unitario
                        });
                        db.SaveChanges();
                        return RedirectToAction("Suelas");
                    }
                    catch
                    {
                        System.Diagnostics.Debug.WriteLine("error");
                    }
                }
            }
            return Content("<script language='javascript' type='text/javascript'>alert('Oh oh... Alguno de los datos importantes que ingresó no se encuentran en la base de datos. Intente de nuevo'); window.location='Suelas'</script>");
            //  return RedirectToAction("Error.cshtml");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult guardaSucursal(MyViewModel v) {
            if (ModelState.IsValid)
            {
                try
                {
                    var db = Utils.GalibelleContext;

                    db.Sucursales.Add(new Sucursales(){
                        nombre_sucursal = v.Sucursales.nombre_sucursal,
                        direccion_sucursal= v.Sucursales.direccion_sucursal,
                        telefono_sucursal = v.Sucursales.telefono_sucursal});
                    db.SaveChanges();

                    int idSuc = (from suc in Utils.GalibelleContext.Sucursales
                                 where suc.nombre_sucursal == v.Sucursales.nombre_sucursal && suc.direccion_sucursal == v.Sucursales.direccion_sucursal 
                                 select suc.IdSucursales).First();
                    System.Diagnostics.Debug.WriteLine(idSuc);
                    

                    db.Usuarios.Add(new Usuarios()
                    {
                        usuario = v.Usuarios.usuario,
                        password =v.Usuarios.password,
                        IdSucursales= idSuc

                    });
                    db.SaveChanges();
                    return RedirectToAction("ListaSucursales");
                }
                catch
                {
                    System.Diagnostics.Debug.WriteLine("error");
                }
            }
            return Content("<script language='javascript' type='text/javascript'>alert('Oh oh... No se pudo registrar la sucursal. Intente de nuevo'); window.location='ListaSucursales'</script>");
            //  return RedirectToAction("Error.cshtml");
        }


    }
}
