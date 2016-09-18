namespace ForoApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Pregunta")]
    public partial class Pregunta
    {
        public Pregunta()
        {
            Comentarios = new HashSet<Comentario>();
        }

        public int ID { get; set; }

        [Required]
        public string Interrogante { get; set; }

        [Required]
        public string Descripcion { get; set; }

        public DateTime Tiempo { get; set; }

        public int Valoracion { get; set; }

        public int CategoriaID { get; set; }

        public int UsuarioID { get; set; }

        public virtual Categoria Categoria { get; set; }

        public virtual ICollection<Comentario> Comentarios { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
