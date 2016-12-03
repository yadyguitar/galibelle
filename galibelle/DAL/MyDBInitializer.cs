using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using galibelle.Models;

namespace galibelle.DAL
{
    public class MyDBInitializer : System.Data.Entity.CreateDatabaseIfNotExists<MyDbContext>
    {
        protected override void Seed(MyDbContext context)
        {
            //context.Colores.Add(new Colores() { nombre_color="red" });
            base.Seed(context);
            
        }
    }
}