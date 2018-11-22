using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiLuzSRL.Models
{
    public interface IProviderRepository
    {
        IEnumerable<Provider> GetProviders();
        Provider Save(Provider provider);
        void Delete(Provider provider);
        Provider FindById(int id);
    }
}
