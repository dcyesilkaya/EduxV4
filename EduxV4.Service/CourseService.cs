using EduxV4.Data;
using EduxV4.Repo;
using System;
using System.Collections.Generic;
using System.Text;
using static EduxV4.Service.CourseService;

namespace EduxV4.Service
{
    public class CourseService : ICourseService
    {
        private readonly IRepository<Course> courseRepository;
        public CourseService(IRepository<Course> courseRepository)
        {
            this.courseRepository = courseRepository;
        }

        public void DeleteCourse(string id)
        {

            Course course = GetCourse(id);
            courseRepository.Remove(course);
            courseRepository.SaveChanges();
        }

        public IEnumerable<Course> GetCourses()
        {
            return courseRepository.GetAll();
        }

        public Course GetCourse(string id)
        {
            return courseRepository.Get(id);
        }

        public void InsertCourse(Course course)
        {
            courseRepository.Insert(course);
        }

        public void UpdateCourse(Course course)
        {
            courseRepository.Update(course);
        }
    }

    public interface ICourseService
        {

            IEnumerable<Course> GetCourses();
            Course GetCourse(string id);
            void InsertCourse(Course course);
            void UpdateCourse(Course course);
            void DeleteCourse(string id);

        }
}

