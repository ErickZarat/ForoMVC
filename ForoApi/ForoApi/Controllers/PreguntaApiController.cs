using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ForoApi.DAL;
using ForoApi.Models;
using System.Web.Http.Cors;

namespace ForoApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class PreguntaApiController : ApiController
    {
        private ForoContext db = new ForoContext();

        // GET: api/PreguntaApi
        public IQueryable<Pregunta> GetPregunta()
        {
            return db.Preguntas;
        }

        public IQueryable<Pregunta> FiltrarFecha(string fecha1, string fecha2)
        {
            return null;
        }

        // GET: api/PreguntaApi/5
        [ResponseType(typeof(Pregunta))]
        public IHttpActionResult GetPregunta(int id)
        {
            Pregunta pregunta = db.Preguntas.Find(id);
            if (pregunta == null)
            {
                return NotFound();
            }

            return Ok(pregunta);
        }

        // PUT: api/PreguntaApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPregunta(int id, Pregunta pregunta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pregunta.ID)
            {
                return BadRequest();
            }

            db.Entry(pregunta).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PreguntaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/PreguntaApi
        [ResponseType(typeof(Pregunta))]
        public IHttpActionResult PostPregunta(Pregunta pregunta)
        {
            pregunta.Tiempo = DateTime.Now;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Preguntas.Add(pregunta);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = pregunta.ID }, pregunta);
        }

        // DELETE: api/PreguntaApi/5
        [ResponseType(typeof(Pregunta))]
        public IHttpActionResult DeletePregunta(int id)
        {
            Pregunta pregunta = db.Preguntas.Find(id);
            if (pregunta == null)
            {
                return NotFound();
            }

            db.Preguntas.Remove(pregunta);
            db.SaveChanges();

            return Ok(pregunta);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PreguntaExists(int id)
        {
            return db.Preguntas.Count(e => e.ID == id) > 0;
        }
    }
}