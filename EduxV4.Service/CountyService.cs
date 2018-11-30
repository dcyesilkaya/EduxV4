using EduxV4.Data;
using EduxV4.Repo;
using System;
using System.Collections.Generic;
using System.Text;

namespace EduxV4.Service
{
   public class CountyService : ICountyService
    {
        private readonly IRepository<County> countyRepository;
        public CountyService(IRepository<County> countyRepository)
        {
            this.countyRepository = countyRepository;
        }

        public void DeleteCounty(string id)
        {
            County county = GetCounty(id);
            countyRepository.Remove(county);
            countyRepository.SaveChanges();
        }

        public County GetCounty(string id)
        {
            return countyRepository.Get(id);
        }

        public IEnumerable<County> GetCounties()
        {
            return countyRepository.GetAll("City");
        }

        public IEnumerable<County> GetCounties(string cityId)
        {
            return countyRepository.GetMany(c=>c.CityId == cityId, "City");
        }

        public void InsertCounty(County county)
        {
            countyRepository.Insert(county);
        }

        public void UpdateCounty(County county)
        {
            countyRepository.Update(county);
        }
    }

    public interface ICountyService
        {
            IEnumerable<County> GetCounties();
            IEnumerable<County> GetCounties(string cityId);
            County GetCounty(string id);
            void InsertCounty(County county);
            void UpdateCounty(County county);
            void DeleteCounty(string id);
        }
    }

