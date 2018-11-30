using EduxV4.Data;
using EduxV4.Repo;
using System;
using System.Collections.Generic;
using System.Text;

namespace EduxV4.Service
{
    public class ActivityService : IActivityService
    {
        private readonly IRepository<Activity> activityRepository;
        public ActivityService(IRepository<Activity> activityRepository)
        {
            this.activityRepository = activityRepository;
        }

        public void DeleteActivity(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Activity> GetActivities()
        {
            throw new NotImplementedException();
        }

        public Activity GetActivity(string id)
        {
            throw new NotImplementedException();
        }

        public void InsertActivity(Activity activity)
        {
            throw new NotImplementedException();
        }

        public void UpdateActivity(Activity activity)
        {
            throw new NotImplementedException();
        }
    }

    public interface IActivityService
    {
        IEnumerable<Activity> GetActivities();
        Activity GetActivity(string id);
        void InsertActivity(Activity activity);
        void UpdateActivity(Activity activity);
        void DeleteActivity(string id);
    }
}
