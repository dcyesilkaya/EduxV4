using EduxV4.Data;
using EduxV4.Repo;
using System;
using System.Collections.Generic;
using System.Text;

namespace EduxV4.Service
{
    public class FamilyService : IFamilyService
    {
        private IRepository<Family> familyRepository;

        public FamilyService(IRepository<Family> familyRepository)
        {
            this.familyRepository = familyRepository;
        }

        public IEnumerable<Family> GetFamilies()
        {
            return familyRepository.GetAll();
        }


        public Family GetFamily(string id)
        {
            return familyRepository.Get(id);
        }

        public void InsertFamily(Family family)
        {
            familyRepository.Insert(family);
        }
        public void UpdateFamily(Family family)
        {
            familyRepository.Update(family);
        }

        public void DeleteFamily(string id)
        {
            Family family = GetFamily(id);
            familyRepository.Remove(family);
            familyRepository.SaveChanges();
        }
    }
    public interface IFamilyService
    {
        IEnumerable<Family> GetFamilies();
        Family GetFamily(string id);
        void InsertFamily(Family family);
        void UpdateFamily(Family family);
        void DeleteFamily(string id);
    }
}

