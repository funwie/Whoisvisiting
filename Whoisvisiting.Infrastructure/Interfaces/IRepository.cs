using System.Linq;
using System.Threading.Tasks;

namespace Whoisvisiting.Infrastructure.Interfaces
{
    public interface IRepository<T>
    {
        Task<T> InsertAsync(T entity);
        T Update(T entity);
        Task<T> GetAsync(int id);
        IQueryable<T> GetAll();
        Task SaveChangesAsync();
        Task<T> DeleteAsync(int id);
    }
}
