using backend.Validations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    public class Images
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ImagesId { get; set; }

        public string? Diretorio { get; set; }

        [Required]
        [ForeignKey("ads_id")]
        public int AdsId { get; set; }

    }
}
