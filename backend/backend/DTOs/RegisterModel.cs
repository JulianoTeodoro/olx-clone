using System.ComponentModel.DataAnnotations;

namespace backend.DTOs
{
    public class RegisterModel
    {
        [Required]
        [StringLength(80, ErrorMessage = "Maximo de 80 caracteres")]
        public string? Nome { get; set; }

        [Required]
        public string? Sobrenome { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        public int StatesId { get; set; }


        [Display(Name = "Confirma senha")]
        [Compare("Password", ErrorMessage = "Senhas não conferem")]
        [DataType(DataType.Password)]
        public string? ConfirmPassword { get; set; }
    }
}
