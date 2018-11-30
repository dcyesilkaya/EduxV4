using EduxV4.Data;
using EduxV4.Repo;
using System;
using System.Collections.Generic;
using System.Text;

namespace EduxV4.Service
{
    public class CityService : ICityService
    {
        private readonly IRepository<City> cityRepository;
        public CityService(IRepository<City> cityRepository)
        {
            this.cityRepository = cityRepository;
        }
        public void DeleteCity(string id)
        {

            City city = GetCity(id);
            cityRepository.Remove(city);
            cityRepository.SaveChanges();
        }

        public IEnumerable<City> GetCities()
        {
            return cityRepository.GetAll("Country");
        }

        public IEnumerable<City> GetCities(string countryId)
        {
            return cityRepository.GetMany(c=>c.CountryId == countryId, "Country");
        }

        public City GetCity(string id)
        {
            return cityRepository.Get(id, "Country");
        }

        public void InsertCity(City city)
        {
            cityRepository.Insert(city);
        }

        public void UpdateCity(City city)
        {
            cityRepository.Update(city);
        }
    }
    public interface ICityService
    {
       
        IEnumerable<City> GetCities();
        IEnumerable<City> GetCities(string countryId);
        City GetCity(string id);
        void InsertCity(City city);
        void UpdateCity(City city);
        void DeleteCity(string id);

    }
}
