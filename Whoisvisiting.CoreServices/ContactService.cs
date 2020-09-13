using System.Threading.Tasks;
using Whoisvisiting.Domain.Entities;
using Whoisvisiting.Infrastructure.Interfaces.CoreServices;
using Whoisvisiting.SqlDataAccess;

namespace Whoisvisiting.CoreServices
{
    public class ContactService : BaseRepository<Contact>, IContactService
    {
        public ContactService(AppDbContext context) : base(context) { }

        public async Task<Contact> AddAsync(Contact entity)
        {
            return await base.InsertAsync(entity);
        }

        public async Task<Contact> FindAsync(int id)
        {
            return await base.GetAsync(id);
        }

        public async Task<Contact> UpdateAsync(Contact entity)
        {
           var trackedContact = base.Update(entity);
           await base.SaveChangesAsync();
            return trackedContact;
        }
    }
}
