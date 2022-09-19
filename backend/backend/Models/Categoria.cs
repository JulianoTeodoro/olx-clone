namespace backend.Models
{
    public class Categoria
    {
        public int CategoriaId { get; set; }
        public string? Nome { get; set; }
        public int Slug { get; set; }
        public ICollection<Ads>? Ads { get; set; }

        public Categoria()
        {
            Ads = new List<Ads>();
        }
    }
}
