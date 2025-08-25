using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Service
{
    public class Libro
    {
        public int id { get; set; }
        [Required]
        public string Titulo { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public int EditorialId { get; set; } =1;
        public Editorial? Editorial { get; set; }
        [Required]
        public int Paginas { get; set; }
        public int AnioPublicacion { get; set; }
        public string Portada { get; set; } = string.Empty;
        [Required]
        [Column(TypeName ="text")]
        public string Sinopsis { get; set; } = string.Empty;

        public override string ToString()
        {
            return Titulo;
        }
        public bool IsDeleted { get; set; } = false;

    }
}
