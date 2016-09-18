using ForoApi.Models;
using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace ForoApi.DAL
{
    public partial class ForoContext : DbContext
    {
        public ForoContext()
            : base("ForoContext")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<Categoria> Categorias { get; set; }
        public virtual DbSet<Comentario> Comentarios { get; set; }
        public virtual DbSet<Pregunta> Preguntas { get; set; }
        public virtual DbSet<Respuesta> Respuestas { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>()
                .HasMany(e => e.Preguntas)
                .WithRequired(e => e.Categoria)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Comentario>()
                .HasMany(e => e.Respuestas)
                .WithRequired(e => e.Comentario)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Pregunta>()
                .HasMany(e => e.Comentarios)
                .WithRequired(e => e.Pregunta)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.Comentarios)
                .WithRequired(e => e.Usuario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.Preguntas)
                .WithRequired(e => e.Usuario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.Respuestas)
                .WithRequired(e => e.Usuario)
                .WillCascadeOnDelete(false);
        }
    }
}
