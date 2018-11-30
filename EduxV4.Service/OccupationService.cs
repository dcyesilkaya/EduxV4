using EduxV4.Data;
using EduxV4.Repo;
using System;
using System.Collections.Generic;
using System.Text;

namespace EduxV4.Service
{
    public class OccupationService : IOccupationService
    {
        private readonly IRepository<Occupation> occupationRepository;
        public OccupationService(IRepository<Occupation> occupationRepository)
        {
            this.occupationRepository = occupationRepository;
        }
        public void DeleteOccupation(string id)
        {
            Occupation occupation = GetOccupation(id);
            occupationRepository.Remove(occupation);
            occupationRepository.SaveChanges();
        }

        public Occupation GetOccupation(string id)
        {
            return occupationRepository.Get(id);
        }

        public IEnumerable<Occupation> GetOccupations()
        {
            return occupationRepository.GetAll();
        }

        public void InsertOccupation(Occupation occupation)
        {
            occupationRepository.Insert(occupation);
        }

        public void UpdateOccupation(Occupation occupation)
        {
            occupationRepository.Update(occupation);
        }
    }
    public interface IOccupationService
    {
        IEnumerable<Occupation> GetOccupations();
        Occupation GetOccupation(string id);
        void InsertOccupation(Occupation activityNextStep);
        void UpdateOccupation(Occupation activityNextStep);
        void DeleteOccupation(string id);



    }
}
