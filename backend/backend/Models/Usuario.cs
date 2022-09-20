using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class Usuario : IdentityUser
    {
        [Required]
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
