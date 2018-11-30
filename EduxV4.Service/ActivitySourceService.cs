using EduxV4.Data;
using EduxV4.Repo;
using System;
using System.Collections.Generic;
using System.Text;

namespace EduxV4.Service
{
    public class ActivitySourceService : IActivitySourceService
    {
        private readonly IRepository<ActivitySource> activitySourceRepository;
        public ActivitySourceService(IRepository<ActivitySource> activitySourceRepository)
        {
            this.activitySourceRepository = activitySourceRepository;
        }

        public void DeleteActivitySource(string id)
        {
            ActivitySource activitySource = GetActivitySource(id);
            activitySourceRepository.Remove(activitySource);
            activitySourceRepository.SaveChanges();
        }

        public ActivitySource GetActivitySource(string id)
        {
            return activitySourceRepository.Get(id);
        }

        public IEnumerable<ActivitySource> GetActivitySources()
        {
            return activitySourceRepository.GetAll(); 
        }

        public void InsertActivitySource(ActivitySource activitySource)
        {
            activitySourceRepository.Insert(activitySource);
        }

        public void UpdateActivitySource(ActivitySource activitySource)
        {
            activitySourceRepository.Update(activitySource);
        }
    }
    public interface IActivitySourceService
    {
        IEnumerable<Data.ActivitySource> GetActivitySources();
        ActivitySource GetActivitySource(string id);
        void InsertActivitySource(ActivitySource activitySource);
        void UpdateActivitySource(ActivitySource activitySource);
        void DeleteActivitySource(string id);
        

    }
}
