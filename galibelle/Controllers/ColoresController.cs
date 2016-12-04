using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using galibelle.Models;

namespace galibelle.Controllers
{
    public class ColoresController : Controller
    {
        
        // GET: Colores
        public ActionResult Index()
        {
            /*
            var db = Utils.GalibelleContext;
            System.Console.WriteLine("Hola, prueba: ", db);
            db.Colores.Add(new Colores() { nombre_color = "red" });
            db.Colores.Add(new Colores() { nombre_color = "black" });
            db.Colores.Add(new Colores() { nombre_color = "red" });
            db.SaveChanges();
            */
            var lista = from x in Utils.GalibelleContext.Colores select x;

           

            return View(lista);
        }

    }
}