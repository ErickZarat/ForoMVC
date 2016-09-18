namespace ForoApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Usuario")]
    public partial class Usuario
    {
        public Usuario()
        {
            Comentarios = new HashSet<Comentario>();
            Preguntas = new HashSet<Pregunta>();
            Respuestas = new HashSet<Respuesta>();
        }

        public int ID { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Apellido { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Contrasena { get; set; }

        [Required]
        public string Role { get; set; }

        public virtual ICollection<Comentario> Comentarios { get; set; }

        public virtual ICollection<Pregunta> Preguntas { get; set; }

        public virtual ICollection<Respuesta> Respuestas { get; set; }
    }
}
