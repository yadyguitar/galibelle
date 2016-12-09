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
        public int IdVentas { get; set; }
        public DateTime fecha_venta { get; set; }

        [Display(Name ="Sucursales")]
        public int IdSucursales { get; set; }

        [ForeignKey("IdSucursales")]
        public virtual IEnumerable<Sucursales> Sucursales { get; set; }
        public virtual ICollection<VendidoStraps> VendidoStraps { get; set; }
        public virtual ICollection<VendidoSuelas> VendidoSuelas { get; set; }

    }
}