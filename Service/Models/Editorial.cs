using System.ComponentModel.DataAnnotations;

namespace Service
{
    public class Editorial
    {
        public int id { get; set; }
        [Required]
        public string nombre { get; set; }
        
    }
    
}
