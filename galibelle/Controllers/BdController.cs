using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using galibelle.Models;

namespace galibelle.Controllers
{
    public class BdController : Controller
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
            //var lista = from x in Utils.GalibelleContext.Colores select x;
            var db = Utils.GalibelleContext;
            db.Sucursales.Add(new Sucursales() { nombre_sucursal = "yadira",direccion_sucursal="Mar de Japon #17",telefono_sucursal="2291404225" });
            db.SaveChanges();
            db.Usuarios.Add(new Usuarios() { IdSucursales=1,usuario="yadira", password="123"});
            db.Colores.Add(new Colores() { nombre_color = "black" });
            db.Colores.Add(new Colores() { nombre_color = "blue" });
            db.Colores.Add(new Colores() { nombre_color = "ocean" });
            db.Colores.Add(new Colores() { nombre_color = "orange" });
            db.Colores.Add(new Colores() { nombre_color = "red" });
            db.Colores.Add(new Colores() { nombre_color = "yellow" });
            db.Colores.Add(new Colores() { nombre_color = "gold" });
            db.Colores.Add(new Colores() { nombre_color = "jaguar" });
            db.Colores.Add(new Colores() { nombre_color = "raw" });
            db.Colores.Add(new Colores() { nombre_color = "pink" });
            db.Colores.Add(new Colores() { nombre_color = "royal" });
            db.Colores.Add(new Colores() { nombre_color = "dark blue" });
            db.Colores.Add(new Colores() { nombre_color = "black silver" });
            db.Colores.Add(new Colores() { nombre_color = "green silver" });
            db.Colores.Add(new Colores() { nombre_color = "pewter" });
            db.Colores.Add(new Colores() { nombre_color = "silver" });
            db.Colores.Add(new Colores() { nombre_color = "floral" });
            db.Colores.Add(new Colores() { nombre_color = "multicolor" });
            db.Colores.Add(new Colores() { nombre_color = "black/white" });
            db.Colores.Add(new Colores() { nombre_color = "pearl" });
            db.Colores.Add(new Colores() { nombre_color = "caramel" });
            db.Colores.Add(new Colores() { nombre_color = "navy blue" });
            db.Colores.Add(new Colores() { nombre_color = "nude" });
            db.Colores.Add(new Colores() { nombre_color = "zebra" });
            db.Colores.Add(new Colores() { nombre_color = "white" });
            db.Colores.Add(new Colores() { nombre_color = "lemon" });
            db.Colores.Add(new Colores() { nombre_color = "peach" });
            db.Colores.Add(new Colores() { nombre_color = "cream" });
            db.Modelos.Add(new Modelos() { nombre_modelo = "gabriela" });
            db.Modelos.Add(new Modelos() { nombre_modelo = "gabi" });
            db.Modelos.Add(new Modelos() { nombre_modelo = "danni" });
            db.Modelos.Add(new Modelos() { nombre_modelo = "bruma" });
            db.Modelos.Add(new Modelos() { nombre_modelo = "deise" });
            db.Modelos.Add(new Modelos() { nombre_modelo = "galuxa" });
            db.Modelos.Add(new Modelos() { nombre_modelo = "giovanna" });
            db.Modelos.Add(new Modelos() { nombre_modelo = "gaya" });
            db.Modelos.Add(new Modelos() { nombre_modelo = "karina" });
            db.Modelos.Add(new Modelos() { nombre_modelo = "michelle" });
            db.Modelos.Add(new Modelos() { nombre_modelo = "naomy" });
            db.Modelos.Add(new Modelos() { nombre_modelo = "noya" });
            db.Modelos.Add(new Modelos() { nombre_modelo = "sara" });
            db.Modelos.Add(new Modelos() { nombre_modelo = "yasmin" });
            db.Modelos.Add(new Modelos() { nombre_modelo = "marimar" });
            db.Modelos.Add(new Modelos() { nombre_modelo = "ivete" });
            db.Modelos.Add(new Modelos() { nombre_modelo = "eva" });
            db.Textura.Add(new Textura() { nombre_Textura = "atanado" });
            db.Textura.Add(new Textura() { nombre_Textura = "canvas" });
            db.Textura.Add(new Textura() { nombre_Textura = "croco" });
            db.Textura.Add(new Textura() { nombre_Textura = "jeans" });
            db.Textura.Add(new Textura() { nombre_Textura = "lurex" });
            db.Textura.Add(new Textura() { nombre_Textura = "metal" });
            db.Textura.Add(new Textura() { nombre_Textura = "micropunto" });
            db.Textura.Add(new Textura() { nombre_Textura = "satin" });
            db.Textura.Add(new Textura() { nombre_Textura = "snake" });
            db.Textura.Add(new Textura() { nombre_Textura = "soft" });
            db.Textura.Add(new Textura() { nombre_Textura = "suede" });
            db.Textura.Add(new Textura() { nombre_Textura = "twill" });
            db.Textura.Add(new Textura() { nombre_Textura = "varnish" });
            db.Textura.Add(new Textura() { nombre_Textura = "braid" });
            db.Sucursales.Add(new Sucursales() { nombre_sucursal = "Sucursal2", direccion_sucursal = "Mar de Japon #17 Fracc. Costa Verde", telefono_sucursal = "2251006309" });
            db.Sucursales.Add(new Sucursales() { nombre_sucursal = "Sucursal3", direccion_sucursal = "Zaragoza esq. M. Molina s/n col.Centro, Veracruz, Ver.", telefono_sucursal = "229200200" });
            db.Sucursales.Add(new Sucursales() { nombre_sucursal = "Sucursal4", direccion_sucursal = "Av. Gómez Farías No.286 Veracruz", telefono_sucursal = "2299328224" });
            db.Usuarios.Add(new Usuarios() { IdSucursales = 2, usuario = "Sucursal2", password = "1111" });
            db.Usuarios.Add(new Usuarios() { IdSucursales = 3, usuario = "Sucursal3", password = "1111" });
            db.Usuarios.Add(new Usuarios() { IdSucursales = 4, usuario = "Sucursal4", password = "1111" });
            db.SaveChanges();

            return View();
        }

    }
}