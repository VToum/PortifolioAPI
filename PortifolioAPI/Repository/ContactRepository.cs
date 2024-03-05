using PortifolioAPI.Data;
using PortifolioAPI.Models;
using PortifolioAPI.Repository.IRepository;

namespace PortifolioAPI.Repository
{
    public class ContactRepository : Repository<Contact>, IContactRepository
    {
        private readonly ContactMeDataContext _dbContact;

        public ContactRepository(ContactMeDataContext dbContact) : base(dbContact)
        {
            _dbContact = dbContact;
        }
    }
}
