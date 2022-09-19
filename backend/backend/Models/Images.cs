using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    public class Images
    {
        [Key]
        public int ImagesId { get; set; }
        [Required]
        public string ImageUrl { get; set; }

        [ForeignKey("ads_id")]
        public int AdsId { get; set; }

    }
}
