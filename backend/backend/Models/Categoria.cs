using backend.Validations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace backend.Models
{
    public class Categoria
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int CategoriaId { get; set; }
        public string? Nome { get; set; }

        [ValidationImage]
        public string? Slug { get; set; }

        //[JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        public ICollection<Ads>? Ads { get; set; }
        public Categoria()
        {
            Ads = new List<Ads>();
        }
    }
}
