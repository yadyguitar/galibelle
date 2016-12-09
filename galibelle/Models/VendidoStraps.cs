using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace galibelle.Models
{
    [Table("VendidoStraps")]
    public class VendidoStraps
    {
        [Key]
        public int IdVendido { get; set; }

        [Display(Name = "Stock_straps")]
        public int IdStock_straps { get; set; }

        
        [Display(Name = "Ventas")]
        public int IdVentas { get; set; }

        public virtual IEnumerable<Stock_straps> Stock_straps { get; set; }
        

        [ForeignKey("IdVentas")]
        public virtual IEnumerable<Ventas> Ventas { get; set; }


    }
}