using MiLuzSRL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiLuzSRL.Controllers
{
    public class ProvidersController : Controller
    {
        private IProviderRepository providerRepository;

        public ProvidersController()
        {
            this.providerRepository = new EFProviderRepository();
        }

        public ProvidersController(IProviderRepository providerRepository)
        {
            this.providerRepository = providerRepository;
        }
        
        public ViewResult Index()
        {
            var providers = providerRepository.GetProviders();

            return View(providers);
        }
        
        public ViewResult New()
        {
            var provider = new Provider();

            return View("ProviderForm", provider);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ViewResult Save(Provider provider)
        {
            /*
            if (!ModelState.IsValid)
            {
                var _provider = new Provider();

                return View("ProviderForm", _provider);
            }

            if (provider.Id == 0)
                _context.Providers.Add(provider);
            else
            {
                var providerInDb = _context.Providers.Single(p => p.Id == provider.Id);
                providerInDb.Id = provider.Id;
                providerInDb.Name = provider.Name;
                providerInDb.PhoneNumber = provider.PhoneNumber;
                providerInDb.Currency = provider.Currency;
                providerInDb.HasDebt = provider.HasDebt;
            }

            _context.SaveChanges();
            */

            providerRepository.Save(provider);

            var providers = providerRepository.GetProviders();

            return View("Index", providers);
        }

        public ActionResult Edit(int id)
        {
            var provider = providerRepository.FindById(id);

            if (provider == null)
                return HttpNotFound();

            return View("ProviderForm", provider);
        }

        public ViewResult Delete(int id)
        {

            var provider = providerRepository.FindById(id);

            /*
            if (provider == null)
                return HttpNotFound();

            _context.Providers.Remove(provider);

            _context.SaveChanges();
            */

            providerRepository.Delete(provider);

            var providers = providerRepository.GetProviders();

            return View("Index", providers);
        }
    }
}
