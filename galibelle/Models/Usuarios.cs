using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace galibelle.Models
{
    [Table("Usuarios")]
    public class Usuarios
    {
        [Key]
        public int IdUsuario { get; set; }

        [Display(Name ="Sucursales")]
        public int IdSucursales { get; set; }

        public string usuario { get; set; }

        [DataType(DataType.Password)]
        public string password { get; set; }

        [ForeignKey("IdSucursales")]
        public virtual Sucursales Sucursales { get; set; }


    }
}