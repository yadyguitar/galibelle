﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace galibelle.Models
{
    public class MyViewModel
    {
        public Stock_straps Stock_straps { get; set; }
        public Straps Straps { get; set; }
        public Colores Colores { get; set; }
        public Pedidos Pedidos { get; set; }
        public Stock_suelas Stock_suelas { get; set; }
        public Sucursales Sucursales { get; set; }
        public Suelas Suelas { get; set; }
        public Textura Textura { get; set; }
        public Tipo_strap Tipo_strap { get; set; }
        public Usuarios Usuarios { get; set; }
        public Vendido Vendido { get; set; }
        public Ventas Ventas { get; set; }
        public Modelos Modelos { get; set; }
    }
}