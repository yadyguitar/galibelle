using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace galibelle.Models
{
    [Table("Stock_suelas")]
    public class Stock_suelas
    {
        [Key]
        public int IdStock_suelas { get; set; }

        [Display(Name ="Suelas")]
        public int IdSuelas { get; set; }

        public float talla_suela { get; set; }
        public int cantidad_suela { get; set; }

        [Display(Name = "Sucursales")]
        public int IdSucursales { get; set; }
        public float precio_suela_unitario { get; set; }
        public int temporada { get; set; }

        [ForeignKey("IdSuelas")]
        public virtual IEnumerable<Suelas> Suelas { get; set; }
        [ForeignKey("IdSucursales")]
        public virtual IEnumerable<Sucursales>Sucursales { get; set; }
    }
}