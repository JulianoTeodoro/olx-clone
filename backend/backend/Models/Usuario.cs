using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class Usuario
    {
        [Key]
        public int UsuarioId { get; set; }

        [Required(ErrorMessage = "O nome é obrigatorio")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "O email é obrigatorio")]
        [EmailAddress]
        public string? Email { get; set; }
        public string? PasswordHash { get; set; }
        public string? Token { get; set; }

        public ICollection<Ads>? Ads { get; set; }
    }
}
