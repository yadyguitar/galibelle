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
        public int id_stock_suelas { get; set; }

        [Display(Name ="Suelas")]
        public int id_suelas { get; set; }

        public float talla_suela { get; set; }
        public int cantidad_suela { get; set; }

        [Display(Name = "Sucursales")]
        public int id_sucursales { get; set; }
        public int temporada { get; set; }
        
        public virtual IEnumerable<Suelas> Suelas { get; set; }
        public virtual IEnumerable<Sucursales>Sucursales { get; set; }
    }
}