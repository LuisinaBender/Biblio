using System.ComponentModel.DataAnnotations;

namespace Service
{
    public class Autor
    {
        public int id { get; set; }
        [Required]
        public string nombre { get; set; }
    }
}
