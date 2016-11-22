using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace galibelle.Models
{
    [Table("Pedidos")]
    public class Pedidos
    {
        [Key]
        public int id_pedidos { get; set; }
        
        [Display(Name ="Suelas")]
        public int id_suelas { get; set; }

        [Display(Name = "Straps")]
        public int id_straps { get; set; }

        [Display(Name = "Sucursales")]
        public int id_sucursales { get; set; }


        public virtual IEnumerable <Suelas> Suelas { get; set; }
        public virtual IEnumerable<Straps> Straps { get; set; }
        public virtual IEnumerable<Sucursales > Sucursales { get; set; }

    }
}