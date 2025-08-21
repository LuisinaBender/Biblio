using System.ComponentModel.DataAnnotations;

namespace Service
{
    public class Genero
    {
        public int id { get; set; }
        [Required]
        public string nombre { get; set; }
    }
}
