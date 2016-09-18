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
    public class RespuestaApiController : ApiController
    {
        private ForoContext db = new ForoContext();

        // GET: api/RespuestaApi
        public IQueryable<Respuesta> GetRespuestas()
        {
            return db.Respuestas;
        }

        // GET: api/RespuestaApi/5
        [ResponseType(typeof(Respuesta))]
        public IHttpActionResult GetRespuesta(int id)
        {
            Respuesta respuesta = db.Respuestas.Find(id);
            if (respuesta == null)
            {
                return NotFound();
            }

            return Ok(respuesta);
        }

        // PUT: api/RespuestaApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRespuesta(int id, Respuesta respuesta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != respuesta.ID)
            {
                return BadRequest();
            }

            db.Entry(respuesta).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RespuestaExists(id))
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

        // POST: api/RespuestaApi
        [ResponseType(typeof(Respuesta))]
        public IHttpActionResult PostRespuesta(Respuesta respuesta)
        {
            respuesta.Tiempo = DateTime.Now;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Respuestas.Add(respuesta);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = respuesta.ID }, respuesta);
        }

        // DELETE: api/RespuestaApi/5
        [ResponseType(typeof(Respuesta))]
        public IHttpActionResult DeleteRespuesta(int id)
        {
            Respuesta respuesta = db.Respuestas.Find(id);
            if (respuesta == null)
            {
                return NotFound();
            }

            db.Respuestas.Remove(respuesta);
            db.SaveChanges();

            return Ok(respuesta);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RespuestaExists(int id)
        {
            return db.Respuestas.Count(e => e.ID == id) > 0;
        }
    }
}