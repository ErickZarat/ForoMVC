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
    public class UsuarioApiController : ApiController
    {
        private ForoContext db = new ForoContext();

        // POST: api/UsuarioApi/Autenticar/
        [ResponseType(typeof(Usuario))]
        public IHttpActionResult Autenticar(string email, string contrasena)
        {
            Usuario usuario = db.Usuarios.FirstOrDefault(
                u => u.Email.Equals(email) && u.Contrasena.Equals(contrasena));
           
            if (usuario == null)
            {
                return NotFound();
            }

            return Ok(usuario);
        }

        // GET: api/UsuarioApi
        public IQueryable<Usuario> GetUsuario()
        {
            return db.Usuarios;
        }

        // GET: api/UsuarioApi/5
        [ResponseType(typeof(Usuario))]
        public IHttpActionResult GetUsuario(int id)
        {
            Usuario usuario = db.Usuarios.Find(id);
            if (usuario == null)
            {
                return NotFound();
            }

            return Ok(usuario);
        }

        // PUT: api/UsuarioApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUsuario(int id, Usuario usuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != usuario.ID)
            {
                return BadRequest();
            }

            db.Entry(usuario).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(id))
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

        // POST: api/UsuarioApi
        [ResponseType(typeof(Usuario))]
        public IHttpActionResult PostUsuario(Usuario usuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Usuarios.Add(usuario);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = usuario.ID }, usuario);
        }

        // DELETE: api/UsuarioApi/5
        [ResponseType(typeof(Usuario))]
        public IHttpActionResult DeleteUsuario(int id)
        {
            Usuario usuario = db.Usuarios.Find(id);
            //eliminar las respuestas del usuario
            db.Respuestas.RemoveRange(db.Respuestas.Where(r => r.Usuario.ID == usuario.ID));
            //elimina los comentarios
            db.Comentarios.RemoveRange(db.Comentarios.Where(c => c.Usuario.ID == usuario.ID));
            //elimina las preguntas
            db.Preguntas.RemoveRange(db.Preguntas.Where(x => x.Usuario.ID == usuario.ID));
            
            if (usuario == null)
            {
                return NotFound();
            }

            db.Usuarios.Remove(usuario);
            db.SaveChanges();

            return Ok(usuario);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UsuarioExists(int id)
        {
            return db.Usuarios.Count(e => e.ID == id) > 0;
        }
    }
}