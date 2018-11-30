using EduxV4.Data;
using EduxV4.Repo;
using System;
using System.Collections.Generic;
using System.Text;

namespace EduxV4.Service
{
    public class ClassLevelService : IClassLevelService
    {
        private readonly IRepository<ClassLevel> classLevelRepository;

        public ClassLevelService(IRepository<ClassLevel> classLevelRepository)
        {
            this.classLevelRepository = classLevelRepository;
        }

        public IEnumerable<ClassLevel> GetClassLevels()
        {
            return classLevelRepository.GetAll();
        }


        public ClassLevel GetClassLevel(string id)
        {
            return classLevelRepository.Get(id);
        }

        public void InsertClassLevel(ClassLevel classLevel)
        {
            classLevelRepository.Insert(classLevel);
        }
        public void UpdateClassLevel(ClassLevel classLevel)
        {
            classLevelRepository.Update(classLevel);
        }

        public void DeleteClassLevel(string id)
        {
            ClassLevel classlevel = GetClassLevel(id);
            classLevelRepository.Remove(classlevel);
            classLevelRepository.SaveChanges();
        }
    }
    public interface IClassLevelService
    {
        IEnumerable<ClassLevel> GetClassLevels();
        ClassLevel GetClassLevel(string id);
        void InsertClassLevel(ClassLevel classlevel);
        void UpdateClassLevel(ClassLevel classlevel);
        void DeleteClassLevel(string id);
    }
}

