using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace galibelle.Models
{
    [Table("VendidoSuelas")]
    public class VendidoSuelas
    {
        [Key]
        public int IdVendido { get; set; }

        
        [Display(Name = "Stock_suelas")]
        public int IdStock_suelas { get; set; }

        [Display(Name = "Ventas")]
        public int IdVentas { get; set; }

    
        public virtual IEnumerable<Stock_suelas> Stock_suelas { get; set; }

        [ForeignKey("IdVentas")]
        public virtual IEnumerable<Ventas> Ventas { get; set; }


    }
}