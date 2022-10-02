using backend.Models;
using System.Threading.Tasks;

namespace backend.Repositories
{
    public interface IAdsRepository: IRepository<Ads>
    {
        Task<IEnumerable<Ads>> GetByTitle(string title);
        Task<Ads> GetAdsById(int id);
    }
}
