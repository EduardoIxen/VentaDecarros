using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VentaDeCarrosIxen.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            if (Session["idUsuario"]!= null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login","Cuenta");
            }
        }
        public ActionResult IndexAdmin()
        {
            return View();
        }
        public ActionResult PaginaPrincipal()
        {
                int id = Convert.ToInt32(Session["idUsuario"]);
                if (id == 2)
                {
                    return RedirectToAction("IndexAdmin", "Home");
                }
            if (Session["idUsuario"]!=null)
            {
                return RedirectToAction("Index","Home");
            }
            else
            {
                return View();
            }
        }
    }
}