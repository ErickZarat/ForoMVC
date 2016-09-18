namespace ForoApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Comentario")]
    public partial class Comentario
    {
        public Comentario()
        {
            Respuestas = new HashSet<Respuesta>();
        }

        public int ID { get; set; }

        [Required]
        public string ComentarioHecho { get; set; }

        public DateTime Tiempo { get; set; }

        public int Valoracion { get; set; }

        public int PreguntaID { get; set; }

        public int UsuarioID { get; set; }

        public virtual Pregunta Pregunta { get; set; }

        public virtual Usuario Usuario { get; set; }

        public virtual ICollection<Respuesta> Respuestas { get; set; }
    }
}
