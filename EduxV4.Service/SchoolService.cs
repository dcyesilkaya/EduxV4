using EduxV4.Data;
using EduxV4.Repo;
using System;
using System.Collections.Generic;
using System.Text;

namespace EduxV4.Service
{
    public class SchoolService : ISchoolService
    {
        private readonly IRepository<School> schoolRepository;
        public SchoolService(IRepository<School> schoolRepository)
        {
            this.schoolRepository = schoolRepository;
        }

        public void DeleteSchool(string id)
        {
            School school = GetSchool(id);
            schoolRepository.Remove(school);
            schoolRepository.SaveChanges();
        }

        public IEnumerable<School> GetSchools()
        {
            return schoolRepository.GetAll();
        }

        public School GetSchool(string id)
        {
            return schoolRepository.Get(id);
        }

        public void InsertSchool(School school)
        {
            schoolRepository.Insert(school);
        }

        public void UpdateSchool(School school)
        {
            schoolRepository.Update(school);
        }
    }
    public interface ISchoolService
    {
        IEnumerable<School> GetSchools();
        School GetSchool(string id);
        void InsertSchool(School school);
        void UpdateSchool(School school);
        void DeleteSchool(string id);
    }
}
