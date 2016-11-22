using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace galibelle.Models
{
    [Table("Vendido")]
    public class Vendido
    {
        [Key]
        public int id_producto_vendido { get; set; }

        [Display(Name ="Stock_straps")]
        public int id_stock_straps { get; set; }

        [Display(Name = "Stock_suelas")]
        public int id_stock_suelas { get; set; }

        [Display(Name = "Ventas")]
        public int id_ventas { get; set; }

        public virtual IEnumerable<Stock_straps> Stock_straps { get; set; }
        public virtual IEnumerable<Stock_suelas> Stock_suelas { get; set; }
        public virtual IEnumerable<Ventas> Ventas { get; set; }
        

    }
}