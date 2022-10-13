using backend.Data;
using backend.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace backend.Repositories
{
    public class AdsRepository : Repository<Ads>, IAdsRepository
    {
        public AdsRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<Ads>> GetByTitle(string title)
        {
            return await GetAsync().Where(p => p.Title == title)/*.Include(p => p.images)*/.ToListAsync(); 
        }

        public Ads GetAdsById(int id)
        {
            return GetAsync().SingleOrDefault(p => p.AdsId == id);
        }

    }
}
