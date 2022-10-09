using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class States
    {
        [Key]
        public int StatesId { get; set; }
        public string? Nome { get; set; }
    }
}
