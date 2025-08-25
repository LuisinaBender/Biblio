using System.ComponentModel.DataAnnotations;

namespace Service.Models
{
    public class Carrera
    {
        public int id {get; set; }
       [Required]
        public string nombre { get; set; }

        public override string ToString()
        {
            return nombre;
        }

        public bool IsDeleted { get; set; } = false;

    }
}
