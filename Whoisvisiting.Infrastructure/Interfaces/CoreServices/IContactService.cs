using System.Linq;
using System.Threading.Tasks;
using Whoisvisiting.Domain.Entities;

namespace Whoisvisiting.Infrastructure.Interfaces.CoreServices
{
    public interface IContactService
    {
        Task<Contact> AddAsync(Contact entity);
        Task<Contact> UpdateAsync(Contact entity);
        Task<Contact> FindAsync(int id);
        IQueryable<Contact> GetAll();
        Task<Contact> DeleteAsync(int id);
    }
}
