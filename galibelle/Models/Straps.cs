using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace galibelle.Models
{
    [Table("Straps")]
    public class Straps
    {
        [Key]
        public int IdStraps { get; set; }
        public string codigo_strap { get; set; }

        [Display(Name = "Modelos")]
        public int IdModelos { get; set; }

        public string imagen_strap { get; set; }

        [ForeignKey("IdModelos")]
        public virtual IEnumerable <Modelos> Modelos { get; set; }
        public virtual ICollection<Stock_straps> Stock_straps { get; set; }
        public virtual ICollection <PedidoStraps> PedidoStraps { get; set; }
    }
}