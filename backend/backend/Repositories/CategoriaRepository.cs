using backend.Data;
using backend.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace backend.Repositories
{
    public class CategoriaRepository : Repository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(AppDbContext context) : base(context)
        {

        }


    }
}
