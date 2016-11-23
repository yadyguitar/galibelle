using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace galibelle.Models
{
    [Table("Textura")]
    public class Textura
    {
        [Key]
        public int IdTextura { get; set; }
        public string nombre_Textura { get; set; }

        public virtual ICollection<Tipo_strap> Tipo_Srap { get; set; }

    }
}