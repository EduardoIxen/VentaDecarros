using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace VentaDeCarrosIxen.Models
{
    public class Archivo
    {
        [Key]
        public int idArchivo { get; set; }
        public String nombre { get; set; }
        public String ContentType { get; set; }
        public FileType tipo { get; set; }
        public Byte[] contenido { get; set; }

        public int idCarro { get; set; }
        public virtual Carro carro { get; set; }

    }
}