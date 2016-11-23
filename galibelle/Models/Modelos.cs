using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace galibelle.Models
{
    [Table("Modelos")]
    public class Modelos
    {
        [Key]
        public int IdModelos { get; set; }
        public string nombre_modelo { get; set; }

        public virtual ICollection<Suelas> Suelas { get; set; }
    }
}