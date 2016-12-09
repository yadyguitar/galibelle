using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace galibelle.Models
{
    [Table("PedidoStraps")]
    public class PedidoStraps
    {
        [Key]
        public int IdPedidos { get; set; }


        [Display(Name = "Straps")]
        public int IdStraps { get; set; }

        [Display(Name = "Sucursales")]
        public int IdSucursales { get; set; }

        
        [ForeignKey("IdStraps")]
        public virtual IEnumerable<Straps> Straps { get; set; }
        [ForeignKey("IdSucursales")]
        public virtual IEnumerable<Sucursales> Sucursales { get; set; }

    }
}