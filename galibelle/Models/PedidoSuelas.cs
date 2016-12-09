using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace galibelle.Models
{
    [Table("PedidoSuelas")]
    public class PedidoSuelas
    {
        [Key]
        public int IdPedidos { get; set; }

        [Display(Name = "Suelas")]
        public int IdSuelas { get; set; }

        [Display(Name = "Sucursales")]
        public int IdSucursales { get; set; }

        [ForeignKey("IdSuelas")]
        public virtual IEnumerable<Suelas> Suelas { get; set; }
        
        [ForeignKey("IdSucursales")]
        public virtual IEnumerable<Sucursales> Sucursales { get; set; }

    }
}