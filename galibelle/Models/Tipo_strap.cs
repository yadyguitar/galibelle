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
        public int id_tipo_strap { get; set; }

        //[ForeignKey("id_colores")]
        [Display (Name ="Colores") ]
        public int id_colores { get; set; }

        //[ForeignKey("id_textura")]
        [Display(Name = "Textura")]
        public int id_textura { get; set; }

        public virtual IEnumerable<Colores> Colores { get; set; }
        public virtual IEnumerable<Textura> Textura { get; set; }
        public virtual ICollection<Stock_straps> Stock_straps { get; set; }
    }
}