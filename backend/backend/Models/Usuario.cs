using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class Usuario : IdentityUser
    {
        [Required]
        [MinLength(2, ErrorMessage = "Minimo de 2 caracteres")]
        [StringLength(80, ErrorMessage = "Maximo de 80 caracteres")]
        public string? Nome { get; set; }

        [Required]
        public string? SobreNome { get; set; }

        public ICollection<Ads>? Ads { get; set; }

        public Usuario()
        {
            Ads = new List<Ads>();
        }
    }
}
