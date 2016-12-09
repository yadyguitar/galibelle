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
        public int IdStock_straps { get; set; }

        [Display(Name = "Straps")]
        public int IdStraps { get; set; }

        [Display(Name = "Tipo_strap")]
        public int IdTipo_strap { get; set; }

        [Display(Name = "Sucursales")]
        public int IdSucursales { get; set; }


        public string size_strap { get; set; }
        public int cantidad { get; set; }
        public float precio_strap_unitario { get; set; }
        public int temporada { get; set; }
        

        [ForeignKey("IdStraps")]
        public virtual IEnumerable<Straps> Straps { get; set; }
        [ForeignKey("IdTipo_strap")]
        public virtual IEnumerable<Tipo_strap> Tipo_strap { get; set; }
        [ForeignKey("IdSucursales")]
        public virtual IEnumerable<Sucursales> Sucursales { get; set; }

        public virtual ICollection<VendidoStraps> VendidoStraps { get; set; }

    }
}