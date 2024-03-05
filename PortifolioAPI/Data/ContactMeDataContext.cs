using Microsoft.EntityFrameworkCore;
using PortifolioAPI.Models;

namespace PortifolioAPI.Data
{
    public class ContactMeDataContext : DbContext
    {
        public ContactMeDataContext(DbContextOptions<ContactMeDataContext> options) : base(options) { }
        
        public DbSet<Contact> contacts { get; set; }
    }
}
