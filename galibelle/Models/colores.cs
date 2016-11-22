using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace galibelle.Models
{
    [Table("colores")]
    public class Colores {
        [Key]
        public int id_colores { get; set; }
        public string nombre_color { get; set; }
    }

}