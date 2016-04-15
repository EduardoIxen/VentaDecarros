using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace VentaDeCarrosIxen.Models
{
    public class Compra
    {
        [Key]
        public int idCompra { get; set; }
        public int cantidad { get; set; }
        public int idCarro { get; set; }
        public virtual Carro carro { get; set; }
        public int idUsuario { get; set; }
        public virtual Usuario usuario { get; set; }

    }
}