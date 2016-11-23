using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace galibelle.Models
{
    [Table("Colores")]
    public class Colores
    {
        [Key]
        public int IdColores { get; set;}
        public string nombre_color { get; set; }

        public virtual ICollection<Tipo_strap> Tipo_strap { get; set; }

    }
}