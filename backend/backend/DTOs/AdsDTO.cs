using backend.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace backend.DTOs
{
    public class AdsDTO
    {
        public int AdsId { get; set; }


        [Required(ErrorMessage = "O titulo de produto é necessário!")]
        [StringLength(80, MinimumLength = 4)]
        public string? Title { get; set; }

        [Required(ErrorMessage = "É necessário ter um usuário!")]
        [StringLength(80, MinimumLength = 4)]
        public string? UsuarioId { get; set; }

        [Required(ErrorMessage = "É necessário ter uma categoria!")]
        public int CategoriaId { get; set; }

        [DefaultValue(0.00)]        
        public double Price { get; set; }

        [Required]
        public bool PriceNegotiable { get; set; }

        public string? Descricao { get; set; }

        [Required]
        public string? Status { get; set; }

        public byte[] Photo { get; set; }

        [Required]
        public int StatesId { get; set; }

    }
}
