using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EduxV4.Data
{
    public class CourseContent:BaseEntity
    {
        [StringLength(200)]
        [Display(Name = "Başlık")]
        public string Title { get; set; }
        [Display(Name = "İçerik")]
        public string Content { get; set; }
        [Display(Name ="Dosya")]
        public string File { get; set; }
        [Display(Name = "Hafta")]
        public int Week { get; set; }

        [Display(Name = "Ders")]
        public string CourseId { get; set; }
        [Display(Name ="Ders")]
        [ForeignKey("CourseId")]
        public Course Course { get; set; }
       
        public virtual ICollection<BranchCourseContent> BranchCourseContents { get; set; }
        public virtual ICollection<ContactCourseContent> ContactCourseContents { get; set; }

        [Display(Name ="Yayınlanma Tarihi")]
        public DateTime? PublishDate { get; set; }
    }
}
