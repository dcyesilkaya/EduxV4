using EduxV4.Data;
using EduxV4.Repo;
using System;
using System.Collections.Generic;
using System.Text;

namespace EduxV4.Service
{
   public class CourseResourceService : ICourseResourceService
    {
        private readonly IRepository<CourseResource> courseResourceRepository;
        public CourseResourceService(IRepository<CourseResource> courseResourceRepository)
        {
            this.courseResourceRepository = courseResourceRepository;
        }

        public void DeleteCourseResource(string id)
        {
            CourseResource courseResource = GetCourseResource(id);
            courseResourceRepository.Remove(courseResource);
            courseResourceRepository.SaveChanges();
        }

        public CourseResource GetCourseResource(string id)
        {
            return courseResourceRepository.Get(id);
        }

        public IEnumerable<CourseResource> GetCourseResources()
        {
            return courseResourceRepository.GetAll();
        }

        public void InsertCourseResource(CourseResource courseResource)
        {
            courseResourceRepository.Insert(courseResource);
        }

        public void UpdateCourseResource(CourseResource courseResource)
        {
            courseResourceRepository.Update(courseResource);
        }
    }
    public interface ICourseResourceService
        {
            IEnumerable<Data.CourseResource> GetCourseResources();
            CourseResource GetCourseResource(string id);
            void InsertCourseResource(CourseResource courseResource);
            void UpdateCourseResource(CourseResource courseResource);
            void DeleteCourseResource(string id);


        }
   
}

