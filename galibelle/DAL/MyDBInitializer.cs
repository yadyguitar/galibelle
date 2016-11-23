using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using galibelle.Models;

namespace galibelle.DAL
{
    public class MyDBInitializer : System.Data.Entity.DropCreateDatabaseAlways<MyDbContext>
    {
        protected override void Seed(MyDbContext context)
        {
            //context.Usuarios.Add(new Usuarios() { Nombre = "Administrador", Contrasena = "12345", Cuenta = "admin" });
            base.Seed(context);
        }
    }
}