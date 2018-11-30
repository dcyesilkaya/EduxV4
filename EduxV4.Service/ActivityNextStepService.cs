using EduxV4.Data;
using EduxV4.Repo;
using System;
using System.Collections.Generic;
using System.Text;

namespace EduxV4.Service
{
    public class ActivityNextStepService : IActivityNextStepService
    {
        private readonly IRepository<ActivityNextStep> activityNextStepRepository;

        public ActivityNextStepService(IRepository<ActivityNextStep> activityNextStepRepository)
        {
            this.activityNextStepRepository = activityNextStepRepository;
        }
        public void DeleteActivityNextStep(string id)
        {
            ActivityNextStep activityNextStep = GetActivityNextStep(id);
            activityNextStepRepository.Remove(activityNextStep);
            activityNextStepRepository.SaveChanges();
        }

        public ActivityNextStep GetActivityNextStep(string id)
        {
            return activityNextStepRepository.Get(id);
        }

        public IEnumerable<ActivityNextStep> GetActivityNextSteps()
        {
            return activityNextStepRepository.GetAll();
        }

        public void InsertActivityNextStep(ActivityNextStep activityNextStep)
        {
            activityNextStepRepository.Insert(activityNextStep);
        }

        public void UpdateActivityNextStep(ActivityNextStep activityNextStep)
        {
            activityNextStepRepository.Update(activityNextStep);
        }
    }
    public interface IActivityNextStepService
    {
        IEnumerable<ActivityNextStep> GetActivityNextSteps();
        ActivityNextStep GetActivityNextStep(string id);
        void InsertActivityNextStep(ActivityNextStep activityNextStep);
        void UpdateActivityNextStep(ActivityNextStep activityNextStep);
        void DeleteActivityNextStep(string id);



    }
}
