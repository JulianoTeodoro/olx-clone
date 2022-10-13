using backend.Data;
using backend.Services;

namespace backend.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private CategoriaRepository? _categoriaRepository;
        private AdsRepository? _adsRepository;

        public AppDbContext _context;

        public ICategoriaRepository CategoriaRepository
        {
            get
            {
                return _categoriaRepository = _categoriaRepository ?? new CategoriaRepository(_context);
            }
        }

        public IAdsRepository AdsRepository
        {
            get
            {
                return _adsRepository = _adsRepository ?? new AdsRepository(_context);
            }
        }

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
