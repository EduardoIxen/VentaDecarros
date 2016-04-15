using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VentaDeCarrosIxen.Models;

namespace VentaDeCarrosIxen.Controllers
{
    public class CarroController : Controller
    {
        private DB_VENTACARROS db = new DB_VENTACARROS();

        // GET: Carro
        public ActionResult Index()
        {
            return View(db.carro.ToList());
        }

        // GET: Carro/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carro carro = db.carro.Find(id);
            if (carro == null)
            {
                return HttpNotFound();
            }
            return View(carro);
        }

        // GET: Carro/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Carro/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idCarro,modelo,marca,precio,color,combustible,kilometros,añoFabricacion,descripcion,cantidad")] Carro carro, HttpPostedFileBase archivo)
        {
            if (ModelState.IsValid)
            {
                if (archivo != null && archivo.ContentLength > 0)
                {
                    var imagen = new Archivo
                    {
                        nombre = System.IO.Path.GetFileName(archivo.FileName),
                        tipo = FileType.Imagen,
                        ContentType = archivo.ContentType
                    };
                    using (var reader = new System.IO.BinaryReader(archivo.InputStream))
                    {
                        imagen.contenido = reader.ReadBytes(archivo.ContentLength);
                    };
                    carro.archivos = new List<Archivo> { imagen };
                }
                db.carro.Add(carro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(carro);
        }

        // GET: Carro/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carro carro = db.carro.Find(id);
            if (carro == null)
            {
                return HttpNotFound();
            }
            return View(carro);
        }

        // POST: Carro/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int? id, HttpPostedFileBase archivo)
        {
            if (id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var carro = db.carro.Find(id);
            if (TryUpdateModel(carro,"",new string[]{"idCarro,modelo,marca,precio,color,combustible,kilometros,añoFabricacion,descripcion,cantidad"}))
            {
                try
                {
                    if (archivo!= null && archivo.ContentLength>0)
                    {
                        if (carro.archivos.Any(f=> f.tipo == FileType.Imagen))
                        {
                            db.archivo.Remove(carro.archivos.First(f=> f.tipo==FileType.Imagen));
                        }
                        var imagen = new Archivo
                        {
                            nombre=System.IO.Path.GetFileName(archivo.FileName),
                            tipo=FileType.Imagen,
                            ContentType=archivo.ContentType
                        };
                        using (var reader = new System.IO.BinaryReader(archivo.InputStream))
                        {
                            imagen.contenido = reader.ReadBytes(archivo.ContentLength);
                        }
                        carro.archivos = new List<Archivo> { imagen };
                    }
                    db.Entry(carro).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch(RetryLimitExceededException){
                    ModelState.AddModelError("", "No se logro guardar los cambios. Intente de nuevo y si el problema persiste, acuda al administrador del sisteam");
                }
            }
            return View(carro);
        }

        // GET: Carro/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carro carro = db.carro.Find(id);
            if (carro == null)
            {
                return HttpNotFound();
            }
            return View(carro);
        }

        // POST: Carro/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Carro carro = db.carro.Find(id);
            db.carro.Remove(carro);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
