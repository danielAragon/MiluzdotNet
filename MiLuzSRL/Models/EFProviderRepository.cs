using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MiLuzSRL.Models
{
    public class EFProviderRepository : IProviderRepository
    {
        ApplicationDbContext _context = new ApplicationDbContext();

        public void Delete(Provider provider)
        {
            _context.Providers.Remove(provider);
            _context.SaveChanges();
        }

        public Provider FindById(int id)
        {
            var provider = _context.Providers.SingleOrDefault(p => p.Id == id);

            return provider;
        }

        public IEnumerable<Provider> GetProviders()
        {
            return _context.Providers.ToList();
        }

        public Provider Save(Provider provider)
        {
            if (provider.Id == 0)
            {
                _context.Providers.Add(provider);
            }
            else
            {
                _context.Entry(provider).State = EntityState.Modified;
            }
            _context.SaveChanges();
            return provider;
        }

    }
}