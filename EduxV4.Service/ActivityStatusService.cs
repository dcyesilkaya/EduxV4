using EduxV4.Data;
using EduxV4.Repo;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace EduxV4.Service
{
    public class ActivityStatusService : IActivityStatusService
    {
        private readonly IRepository<ActivityStatus> activityStatusRepository;
        public ActivityStatusService(IRepository<ActivityStatus> activityStatusRepository)
        {
            this.activityStatusRepository = activityStatusRepository;
        }
        public void DeleteActivityStatus(string id)
        {
            ActivityStatus activityStatus = GetActivityStatus(id);
            activityStatusRepository.Remove(activityStatus);
            activityStatusRepository.SaveChanges();
        }

        public ActivityStatus GetActivityStatus(string id)
        {
            return activityStatusRepository.Get(id);
        }

        public IEnumerable<ActivityStatus> GetActivityStatuses()
        {
            return activityStatusRepository.GetAll();
        }

        public void InsertActivityStatus(ActivityStatus activityStatus)
        {
            activityStatusRepository.Insert(activityStatus);
        }

        public void UpdateActivityStatus(ActivityStatus activityStatus)
        {
            activityStatusRepository.Update(activityStatus);
        }
    }
    public interface IActivityStatusService
    {
        IEnumerable<ActivityStatus> GetActivityStatuses();
        ActivityStatus GetActivityStatus(string id);
        void InsertActivityStatus(ActivityStatus activityStatus);
        void UpdateActivityStatus(ActivityStatus activityStatus);
        void DeleteActivityStatus(string id);

    }
}
