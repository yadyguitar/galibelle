using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace galibelle.Models
{
    [Table("Stock_straps")]
    public class Stock_straps
    {
        [Key]
        public int id_stock_straps { get; set; }

        [Display(Name = "Straps")]
        public int id_strap { get; set; }

        [Display(Name = "Tipo_strap")]
        public int id_tipo_strap { get; set; }

        [Display(Name = "Sucursales")]
        public int id_sucursales { get; set; }

        public string size_strap { get; set; }
        public int cantidad { get; set; }
        public int temporada { get; set; }
        

        public virtual IEnumerable<Straps> Straps { get; set; }
        public virtual IEnumerable<Tipo_strap> Tipo_strap { get; set; }
        public virtual IEnumerable<Sucursales> Sucursales { get; set; }
        public virtual ICollection<Vendido> Vendido { get; set; }

    }
}