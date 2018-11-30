using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EduxV4.Data
{
    public class Branch:BaseEntity
    {
        [Display(Name = "Ad")]
        public string Name { get; set; }
        [Display(Name = "Sınıf Seviyesi")]
        public string ClassLevelId { get; set; }
        [ForeignKey("ClassLevelId")]
        [Display(Name = "Sınıf Seviyesi")]
        public ClassLevel ClassLevel { get; set; }
        [Display(Name = "Oda")]
        public string RoomId { get; set; }
        [ForeignKey("RoomId")]
        [Display(Name = "Oda")]
        public Room Room { get; set; }
        public virtual ICollection<BranchHomework> BranchHomeworks { get; set; }
        public virtual ICollection<BranchAnnouncement> BranchAnnouncements { get; set; }
        public virtual ICollection<BranchCourseContent> BranchCourseContents { get; set; }
        public virtual ICollection<CourseResource> CourseResources { get; set; }
    }
}
