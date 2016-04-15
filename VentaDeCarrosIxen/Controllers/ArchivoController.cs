using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VentaDeCarrosIxen.Models;
using VentaDeCarrosIxen.Controllers;

namespace VentaDeCarrosIxen.Controllers
{
    public class ArchivoController : Controller
    {
        public DB_VENTACARROS db = new DB_VENTACARROS();
        // GET: Archivo
        public ActionResult ObtenerArchivo(int id)
        {
            var imagen = db.archivo.Find(id);
            return File(imagen.contenido, imagen.ContentType);
        }
    }
}