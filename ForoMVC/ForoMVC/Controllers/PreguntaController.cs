using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ForoMVC.Controllers
{
    public class PreguntaController : Controller
    {
        // GET: Pregunta
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TraerID(int idPregunta)
        {
            ViewBag.idSeleccionado = idPregunta;
            return View("../Home/Index");
        }
    }
}