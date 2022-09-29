using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace backend.Models
{
    public class Ads
    {
        [Key]
        public int AdsId { get; set; }

        [Required(ErrorMessage = "O titulo de produto é necessário!")]
        [StringLength(80, MinimumLength = 4)]
        public string? Title { get; set; }

        public string? UsuarioId { get; set; }

        public DateTime dateCreated { get; set; }

        [ForeignKey("categoria_id")]
        public int CategoriaId { get; set; }

        [Required(ErrorMessage = "O preço é necessário!")]
        [Column(TypeName = "decimal(10,2)")]
        [Range(1, 10000, ErrorMessage = "O preço deve estar entre {1} e {2}")]
        public double Price { get; set; }

        [Required]
        public bool PriceNegotiable { get; set; }

        [Required(ErrorMessage = "É obrigatorio a descrição")]
        public string? Descricao { get; set; }

        public int views { get; set; }

        [Required]
        public string? Status { get; set; }
        public ICollection<Images>? images { get; set; }

        [Required]
        public int StatesId { get; set; }

        public Ads()
        {
            images = new List<Images>();
        }
    }
}
