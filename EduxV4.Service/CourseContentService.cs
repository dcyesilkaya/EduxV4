using EduxV4.Data;
using EduxV4.Repo;
using System;
using System.Collections.Generic;
using System.Text;

namespace EduxV4.Service
{
    public class CourseContentService:ICourseContentService
    {
        private readonly IRepository<CourseContent> courseContentRepository;
        public CourseContentService(IRepository<CourseContent> courseContentRepository)
        {
            this.courseContentRepository = courseContentRepository;
        }

        public void DeleteCourseContent(string id)
        {
            CourseContent courseContent = GetCourseContent(id);
            courseContentRepository.Remove(courseContent);
            courseContentRepository.SaveChanges();
        }

        public CourseContent GetCourseContent(string id)
        {
            return courseContentRepository.Get(id);
        }

        public IEnumerable<CourseContent> GetCourseContents()
        {
            return courseContentRepository.GetAll("Course");
        }

        public void InsertCourseContent(CourseContent courseContent)
        {
            courseContentRepository.Insert(courseContent);
        }

        public void UpdateCourseContent(CourseContent courseContent)
        {
            courseContentRepository.Update(courseContent);
        }
    }
    public interface ICourseContentService
    {
        IEnumerable<CourseContent> GetCourseContents();
        CourseContent GetCourseContent(string id);
        void InsertCourseContent(CourseContent courseContent);
        void UpdateCourseContent(CourseContent courseContent);
        void DeleteCourseContent(string id);
    }
}
