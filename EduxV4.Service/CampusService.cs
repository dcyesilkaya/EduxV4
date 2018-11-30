using EduxV4.Data;
using EduxV4.Repo;
using System;
using System.Collections.Generic;
using System.Text;

namespace EduxV4.Service
{
    public class CampusService : ICampusService
    {
        private readonly IRepository<Campus> campusRepository;
        public CampusService(IRepository<Campus> campusRepository)
        {
            this.campusRepository = campusRepository;
        }

        public void DeleteCampus(string id)
        {
            Campus campus = GetCampus(id);
            campusRepository.Remove(campus);
            campusRepository.SaveChanges();
        }

        public Campus GetCampus(string id)
        {
            return campusRepository.Get(id);
        }

        public IEnumerable<Campus> GetCampuses()
        {
            return campusRepository.GetAll();
        }

        public void InsertCampus(Campus campus)
        {
            campusRepository.Insert(campus);
        }

        public void UpdateCampus(Campus campus)
        {
            campusRepository.Update(campus);
        }
    }

    public interface ICampusService
    {
        IEnumerable<Campus> GetCampuses();
        Campus GetCampus(string id);
        void InsertCampus(Campus campus);
        void UpdateCampus(Campus contact);
        void DeleteCampus(string id);
    }
}
