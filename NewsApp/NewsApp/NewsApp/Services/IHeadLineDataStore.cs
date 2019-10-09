using System.Threading.Tasks;
using NewsApp.Models;

namespace NewsApp.Services
{
    public interface IHeadLineDataStore
    {
        Task<HeadLine> GetNewsBySourceNameAsync(string sourcename);
    }
}
