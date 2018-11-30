using System;
using System.Collections.Generic;
using System.Text;

namespace EduxV4.Data
{
    public class BranchAnnouncement
    {
        public string BranchId { get; set; }
        public Branch Branch { get; set; }

        public string AnnouncementId { get; set; }
        public Announcement Announcement { get; set; }
    }
}
