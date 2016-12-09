using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace galibelle.Models
{
    [Table("Sucursales")]
    public class Sucursales
    {
        [Key]
        public int IdSucursales { get; set; }

        public string nombre_sucursal { get; set; }
        public string direccion_sucursal { get; set; }
        public string telefono_sucursal { get; set; }

        public virtual ICollection<Stock_straps> Stock_straps { get; set; }
        public virtual ICollection<Stock_suelas> Stock_suelas { get; set; }
        public virtual ICollection<Ventas> Ventas { get; set; }
        public virtual ICollection<PedidoStraps> PedidoStraps { get; set; }
        public virtual ICollection<PedidoSuelas> PedidoSuelas { get; set; }
        public virtual ICollection<Usuarios> Usuarios { get; set; }
    }
}