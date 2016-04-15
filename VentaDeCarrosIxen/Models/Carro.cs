using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace VentaDeCarrosIxen.Models
{
    public class Carro
    {
        [Key]
        public int idCarro { get; set; }
        [Display(Name="Modelo"), Required(ErrorMessage="Modelo es obligatorio")]
        public String modelo { get; set; }
        [Display(Name="Marca"), Required(ErrorMessage="Marca es obligatorio")]
        public String marca { get; set; }
        [Display(Name="Precio"), Required(ErrorMessage="Precio es obligatorio")]
        public String precio { get; set; }
        [Display(Name="Color")]
        public String color { get; set; }
        [Display(Name="Combustible")]
        public String combustible { get; set; }
        [Display(Name="Kilometros")]
        public int kilometros { get; set; }
        [Display(Name = "Año Fabricacion"), Required(ErrorMessage = "Año es oblligatoria")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime añoFabricacion { get; set; }
        [Display(Name="Descripción es obligatorio")]
        public String descripcion { get; set; }
        [Display(Name="Cantidad"), Required(ErrorMessage="Cantidad es obligatorio")]
        public int cantidad { get; set; }
        public virtual List<Archivo> archivos { get; set; }
        public virtual List<Compra> compra { get; set; }

    }
}