using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace galibelle.Models
{
    [Table("Suelas")]
    public class Suelas
    {
        [Key]
        public int IdSuelas { get; set; }

        [Display(Name="Modelos")]
        public int IdModelos { get; set; }

        public string nombre_suela { get; set; }
        
        public string imagen_suela { get; set; }
        [ForeignKey("IdModelos")]
        public virtual IEnumerable<Modelos> Modelos { get; set; }
        public virtual ICollection<PedidoSuelas> PedidoSuelas { get; set; }
        public virtual ICollection<Stock_suelas> Stock_suelas { get; set; }
    }
}