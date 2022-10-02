using backend.Data;
using backend.Models;

namespace backend.Repositories
{
    public class ImageRepository: Repository<Images>, IimageRepository
    {
        public ImageRepository(AppDbContext context): base(context) { }
    }
}
