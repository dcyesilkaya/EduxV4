using EduxV4.Data;
using EduxV4.Repo;
using System;
using System.Collections.Generic;
using System.Text;

namespace EduxV4.Service
{
    public class AnnouncementService : IAnnouncementService
    {
        private readonly IRepository<Announcement> announcementRepository;
        public AnnouncementService(IRepository<Announcement> announcementRepository)
        {
            this.announcementRepository = announcementRepository;
        }

        public void DeleteAnnouncement(string id)
        {
            Announcement announcement = GetAnnouncement(id);
            announcementRepository.Remove(announcement);
            announcementRepository.SaveChanges();
        }

        public Announcement GetAnnouncement(string id)
        {
            return announcementRepository.Get(id);
        }

        public IEnumerable<Announcement> GetAnnouncements()
        {
            return announcementRepository.GetAll();
        }

        public void InsertAnnouncement(Announcement announcement)
        {
            announcementRepository.Insert(announcement);
        }

        public void UpdateAnnouncement(Announcement announcement)
        {
            announcementRepository.Update(announcement);
        }
    }
    public interface IAnnouncementService
    {
        IEnumerable<Announcement> GetAnnouncements();
        Announcement GetAnnouncement(string id);
        void InsertAnnouncement(Announcement announcement);
        void UpdateAnnouncement(Announcement announcement);
        void DeleteAnnouncement(string id);
    }
}
