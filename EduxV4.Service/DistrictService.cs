using EduxV4.Data;
using EduxV4.Repo;
using System;
using System.Collections.Generic;
using System.Text;
using static EduxV4.Service.DistrictService;

namespace EduxV4.Service
{
    public class DistrictService : IDistrictService
    {
        public readonly IRepository<District> districtRepository; 
        public DistrictService(IRepository<District> districtRepository)
        {
            this.districtRepository = districtRepository;
        }
        public void DeleteDistrict(string id)
        {
            District district = GetDistrict(id);
            districtRepository.Remove(district);
            districtRepository.SaveChanges();

        }

        public District GetDistrict(string id)
        {
           return districtRepository.Get(id);
        }

        public IEnumerable<District> GetDistricts()
        {
            return districtRepository.GetAll("County");
        }

        public IEnumerable<District> GetDistricts(string countyId)
        {
            return districtRepository.GetMany(d=>d.CountyId == countyId, "County");
        }

        public void InsertDistrict(District district)
        {
            districtRepository.Insert(district);
        }

        public void UpdateDistrict(District district)
        {
            districtRepository.Update(district);
        }
    }
    public interface IDistrictService
        {
            IEnumerable<District> GetDistricts();
            IEnumerable<District> GetDistricts(string countyId);
            District GetDistrict(string id);
            void InsertDistrict(District district);
            void UpdateDistrict(District district);
            void DeleteDistrict(string id);
        }
    }

