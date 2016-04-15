using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace VentaDeCarrosIxen.Models
{
    public class Rol
    {
        [Key]

        public int idRol { get; set; }
        [Display(Name="Nombre"),Required(ErrorMessage="Nombre es requerido")]
        public String nombre { get; set; }
        [Display(Name="Descripcion"), Required(ErrorMessage="Descripcion es requerido")]
        public String descripcion { get; set; }
        public virtual List<Usuario> usuarios { get; set; }

    }
}