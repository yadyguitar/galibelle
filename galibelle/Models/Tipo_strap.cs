using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace galibelle.Models
{
    [Table("Tipo_strap")]
    public class Tipo_strap
    {
        [Key]
        public int IdTipo_strap { get; set; }

        //[ForeignKey("IdColores")]
        [Display (Name ="Colores") ]
        public int IdColores { get; set; }

        //
        [Display(Name = "Textura")]
        public int IdTextura { get; set; }

        [ForeignKey("IdColores")]
        public virtual IEnumerable<Colores> Colores { get; set; }
        [ForeignKey("IdTextura")]
        public virtual IEnumerable<Textura> Textura { get; set; }
        public virtual ICollection<Stock_straps> Stock_straps { get; set; }
    }
}