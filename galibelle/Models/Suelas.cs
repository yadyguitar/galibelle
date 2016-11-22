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
        public int id_suelas { get; set; }

        [Display(Name="Modelos")]
        public int id_modelos { get; set; }

        public string nombre_suela { get; set; }
        public float precio_suela { get; set; }

        public virtual IEnumerable<Modelos> Modelos { get; set; }
        public virtual ICollection<Pedidos> Pedidos { get; set; }
        public virtual ICollection<Stock_suelas> Stock_suelas { get; set; }
    }
}