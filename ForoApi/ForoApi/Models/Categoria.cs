namespace ForoApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Categoria")]
    public partial class Categoria
    {
        public Categoria()
        {
            Preguntas = new HashSet<Pregunta>();
        }

        public int ID { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Descripcion { get; set; }

        public virtual ICollection<Pregunta> Preguntas { get; set; }
    }
}
