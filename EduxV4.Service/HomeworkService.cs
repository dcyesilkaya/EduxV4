using EduxV4.Data;
using EduxV4.Repo;
using System;
using System.Collections.Generic;
using System.Text;
using static EduxV4.Service.HomeworkService;

namespace EduxV4.Service
{
    public class HomeworkService : IHomeworkService
    {
        private readonly IRepository<Homework> homeworkRepository;
        public HomeworkService(IRepository<Homework> homeworkRepository)
        {
            this.homeworkRepository = homeworkRepository;
        }

        public void DeleteHomework(string id)
        {
            Homework homework = GetHomework(id);
            homeworkRepository.Remove(homework);
            homeworkRepository.SaveChanges();
        }

        public IEnumerable<Homework> GetHomeworks()
        {
            return homeworkRepository.GetAll("Course");
        }

        public Homework GetHomework(string id)
        {
            return homeworkRepository.Get(id, "Course");
        }

        public void InsertHomework(Homework homework)
        {
            homeworkRepository.Insert(homework);
        }

        public void UpdateHomework(Homework homework)
        {
            homeworkRepository.Update(homework);
        }

        public interface IHomeworkService
        {

            IEnumerable<Homework> GetHomeworks();
            Homework GetHomework(string id);
            void InsertHomework(Homework homework);
            void UpdateHomework(Homework homework);
            void DeleteHomework(string id);

        }
    }
}
