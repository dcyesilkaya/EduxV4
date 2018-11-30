using EduxV4.Data;
using EduxV4.Repo;
using System;
using System.Collections.Generic;
using System.Text;

namespace EduxV4.Service
{
    public class ActivityTypeService : IActivityTypeService
    {
        private readonly IRepository<ActivityType> activityTypeRepository;
        public ActivityTypeService(IRepository<ActivityType> activityTypeRepository)
        {
            this.activityTypeRepository = activityTypeRepository;
        }

        public void DeleteActivityType(string id)
        {
            ActivityType activityType = GetActivityType(id);
            activityTypeRepository.Remove(activityType);
            activityTypeRepository.SaveChanges();
        }

        public ActivityType GetActivityType(string id)
        {
            return activityTypeRepository.Get(id);
        }

        public IEnumerable<ActivityType> GetActivityTypes()
        {
            return activityTypeRepository.GetAll();
        }

        public void InsertActivityType(ActivityType activityType)
        {
            activityTypeRepository.Insert(activityType);
        }

        public void UpdateActivityType(ActivityType activityType)
        {
            activityTypeRepository.Update(activityType);
        }
    }

    public interface IActivityTypeService
    {
        IEnumerable<ActivityType> GetActivityTypes();
        ActivityType GetActivityType(string id);
        void InsertActivityType(ActivityType activityType);
        void UpdateActivityType(ActivityType activityType);
        void DeleteActivityType(string id);

    }
}
