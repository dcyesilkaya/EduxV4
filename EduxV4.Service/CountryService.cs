using EduxV4.Data;
using EduxV4.Repo;
using System;
using System.Collections.Generic;
using System.Text;
using static EduxV4.Service.CountryService;

namespace EduxV4.Service
{
    public class CountryService : ICountryService
    {
        private readonly IRepository<Country> countryRepository;

        public CountryService(IRepository<Country> countryRepository)
        {
            this.countryRepository = countryRepository;
        }

        public void DeleteCountry(string id)
        {
            Country country = GetCountry(id);
            countryRepository.Remove(country);
            countryRepository.SaveChanges();

        }

        public IEnumerable<Country> GetCountries()
        {
            return countryRepository.GetAll();
        }

        public Country GetCountry(string id)
        {
            return countryRepository.Get(id);
        }

        public void InsertCountry(Country country)
        {
            countryRepository.Insert(country);
        }

        public void UpdateCountry(Country country)
        {
            countryRepository.Update(country);
        }
    }
    public interface ICountryService
    {

        IEnumerable<Country> GetCountries();
        Country GetCountry(string id);
        void InsertCountry(Country country);
        void UpdateCountry(Country country);
        void DeleteCountry(string id);

    }
}
