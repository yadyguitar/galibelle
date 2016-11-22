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
        public int id_straps { get; set; }
        public string codigo_strap { get; set; }

        [Display(Name = "Modelos")]
        public int id_modelo { get; set; }

        public string letra_strap { get; set; }
        public float precio_strap { get; set; }
        public virtual IEnumerable <Modelos> Modelos { get; set; }
        public virtual ICollection<Stock_straps> Stock_straps { get; set; }
        public virtual ICollection <Pedidos> Pedidos { get; set; }
    }
}