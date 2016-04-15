using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace VentaDeCarrosIxen.Models
{
    public class Usuario
    {
        [Key]
        public int idUsuario { get; set; }
        [Display(Name="Nombre"),Required(ErrorMessage="Nombre es requerido")]
        public String nombre { get; set; }
        [Display(Name="Correo"),Required(ErrorMessage="Correo es requerido"), DataType(DataType.EmailAddress)]
        public String correo { get; set; }
        [Display(Name="Contraseña"),Required(ErrorMessage="Contraseña es requerida"),DataType(DataType.Password)]
        public String contraseña { get; set; }
        [Display(Name="Confirmar Contraseña"),Required(ErrorMessage="Este campo es obligatorio"),DataType(DataType.Password)]
        [Compare("contraseña",ErrorMessage="Las contraseñas no coiciden")]
        public String confirmarContraseña { get; set; }

        public int idRol { get; set; }
        public virtual Rol rol { get; set; }
        public virtual List<Compra> compra { get; set; }


    }
}