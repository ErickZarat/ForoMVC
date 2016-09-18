namespace ForoApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Respuesta")]
    public partial class Respuesta
    {
        public int ID { get; set; }

        [Required]
        public string RespuestaHecha { get; set; }

        public DateTime Tiempo { get; set; }

        public int Valoracion { get; set; }

        public int ComentarioID { get; set; }

        public int UsuarioID { get; set; }

        public virtual Comentario Comentario { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
