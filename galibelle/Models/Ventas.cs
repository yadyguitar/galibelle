using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace galibelle.Models
{
    [Table("Ventas")]
    public class Ventas
    {
        [Key]
        public int id_ventas { get; set; }
        public DateTime fecha_venta { get; set; }
        public double precio_Total { get; set; }

        [Display(Name ="Sucursales")]
        public int id_sucursales { get; set; }

        public virtual IEnumerable<Sucursales> Sucursales { get; set; }
        public virtual ICollection<Vendido> Vendido { get; set; }

    }
}