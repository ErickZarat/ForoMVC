using ForoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ForoApi.DAL
{
    public class ForoInitializer : DropCreateDatabaseIfModelChanges<ForoContext>
    {
        protected override void Seed(ForoContext context)
        {
            var categorias = new List<Categoria>()
            {
                new Categoria{ID=1, Nombre="Android", Descripcion="Categoria relacionada con temas de terminales android"},
                new Categoria{ID=1, Nombre="Celulares", Descripcion="Categoria relacionada con celulares"},
                new Categoria{ID=1, Nombre="Java", Descripcion="Categoria relacionada con temas de programacion java"},
                new Categoria{ID=1, Nombre="Wears", Descripcion="Categoria relacionada con Android Wear"}
            };

            categorias.ForEach(c => context.Categorias.Add(c));
            context.SaveChanges();

            var usuarios = new List<Usuario>()
            {
                new Usuario{ID=1, Nombre="Erick", Apellido="Zarat", Email="ez@gmail.com", Contrasena="1234", Role="admin"},
                new Usuario{ID=2, Nombre="Juan", Apellido="Perez", Email="jp@gmail.com", Contrasena="1234", Role="client"},
                new Usuario{ID=3, Nombre="Jose", Apellido="Solis", Email="js@outlook.com", Contrasena="1234", Role="client"},
                new Usuario{ID=4, Nombre="Alberto", Apellido="Diaz", Email="ad@yahoo.com", Contrasena="1234", Role="client"}
            };
            usuarios.ForEach(s => context.Usuarios.Add(s));
            context.SaveChanges();

            var preguntas = new List<Pregunta>()
            {
                new Pregunta{ID=1, UsuarioID=usuarios[0].ID, Interrogante="pregunta 1", Tiempo=DateTime.Now, CategoriaID=categorias[0].ID, Descripcion="descripcion de la pregunta 1", Valoracion=2},
                new Pregunta{ID=2, UsuarioID=usuarios[1].ID, Interrogante="pregunta 2", Tiempo=DateTime.Now, CategoriaID=categorias[1].ID, Descripcion="descripcion de la pregunta 2", Valoracion=0},
                new Pregunta{ID=3, UsuarioID=usuarios[2].ID, Interrogante="pregunta 3", Tiempo=DateTime.Now, CategoriaID=categorias[2].ID, Descripcion="descripcion de la pregunta 3", Valoracion=1},
                new Pregunta{ID=4, UsuarioID=usuarios[3].ID, Interrogante="pregunta 4", Tiempo=DateTime.Now, CategoriaID=categorias[3].ID, Descripcion="descripcion de la pregunta 4", Valoracion=3},
            };
            preguntas.ForEach(s => context.Preguntas.Add(s));
            context.SaveChanges();

            var comentarios = new List<Comentario>()
            {
                new Comentario {ID=1, PreguntaID=preguntas[1].ID, Tiempo=DateTime.Now, UsuarioID=usuarios[0].ID, ComentarioHecho="comentario 1", Valoracion=4},
                new Comentario {ID=2, PreguntaID=preguntas[2].ID, Tiempo=DateTime.Now, UsuarioID=usuarios[1].ID, ComentarioHecho="comentario 2", Valoracion=0},
                new Comentario {ID=3, PreguntaID=preguntas[0].ID, Tiempo=DateTime.Now, UsuarioID=usuarios[2].ID, ComentarioHecho="comentario 3", Valoracion=8},
                new Comentario {ID=4, PreguntaID=preguntas[3].ID, Tiempo=DateTime.Now, UsuarioID=usuarios[3].ID, ComentarioHecho="comentario 4", Valoracion=2}
            };
            comentarios.ForEach(c => context.Comentarios.Add(c));
            context.SaveChanges();

            var respuestas = new List<Respuesta>()
            {
                new Respuesta{ID=1, ComentarioID=comentarios[1].ID, Tiempo=DateTime.Now, UsuarioID=usuarios[3].ID, Valoracion=4, RespuestaHecha="respuesta 1"},
                new Respuesta{ID=2, ComentarioID=comentarios[0].ID, Tiempo=DateTime.Now, UsuarioID=usuarios[1].ID, Valoracion=4, RespuestaHecha="respuesta 2"},
                new Respuesta{ID=3, ComentarioID=comentarios[3].ID, Tiempo=DateTime.Now, UsuarioID=usuarios[2].ID, Valoracion=4, RespuestaHecha="respuesta 4"},
                new Respuesta{ID=4, ComentarioID=comentarios[2].ID, Tiempo=DateTime.Now, UsuarioID=usuarios[0].ID, Valoracion=4, RespuestaHecha="respuesta 3"}
            };
            respuestas.ForEach(r => context.Respuestas.Add(r));
            context.SaveChanges();
        }
    }
}