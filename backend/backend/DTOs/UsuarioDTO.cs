using backend.Models;
using System.ComponentModel.DataAnnotations;

namespace backend.DTOs
{
    public class UsuarioDTO
    {
        [Required(ErrorMessage = "O nome é obrigatorio")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "O email é obrigatorio")]
        [EmailAddress]
        public string? Email { get; set; }

        public string Token { get; set; }
        public DateTime Expiration { get; set; }

        public ICollection<Ads>? Ads { get; set; }
    }
}
