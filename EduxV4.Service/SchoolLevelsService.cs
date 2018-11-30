using EduxV4.Data;
using EduxV4.Repo;
using System;
using System.Collections.Generic;
using System.Text;

namespace EduxV4.Service
{
    public class SchoolLevelService : ISchoolLevelService
    {
        private readonly IRepository<SchoolLevel> schoolLevelRepository;
        public SchoolLevelService(IRepository<SchoolLevel> schoolLevelRepository)
        {
            this.schoolLevelRepository = schoolLevelRepository;
        }

        public void DeleteSchoolLevel(string id)
        {
            SchoolLevel schoolLevel = GetSchoolLevel(id);
            schoolLevelRepository.Remove(schoolLevel);
            schoolLevelRepository.SaveChanges();
        }

        public SchoolLevel GetSchoolLevel(string id)
        {
            return schoolLevelRepository.Get(id);
        }

        public IEnumerable<SchoolLevel> GetSchoolLevels()
        {
            return schoolLevelRepository.GetAll();
        }

        public void InsertSchoolLevel(SchoolLevel schoolLevel)
        {
            schoolLevelRepository.Insert(schoolLevel);
        }

        public void UpdateSchoolLevel(SchoolLevel schoolLevel)
        {
            schoolLevelRepository.Update(schoolLevel);
        }
    }

    public interface ISchoolLevelService
    {
        IEnumerable<SchoolLevel> GetSchoolLevels();
        SchoolLevel GetSchoolLevel(string id);
        void InsertSchoolLevel(SchoolLevel schoolLevel);
        void UpdateSchoolLevel(SchoolLevel schoolLevel);
        void DeleteSchoolLevel(string id);

    }
}
