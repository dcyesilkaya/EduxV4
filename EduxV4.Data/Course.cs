using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EduxV4.Data
{
    public class Course:BaseEntity
    {
        [Display(Name = "Ad")]
        public string Name { get; set; }
        [Display(Name = "Kod")]
        public string Code { get; set; }
        [Display(Name = "Sabit Mi?")]
        public bool IsFixed { get; set; }
        [Display(Name = "Sınav Durumu")]
        public ExamStatus ExamStatus { get; set; }
        [Display(Name = "Durum")]
        public Status Status { get; set; }

        public virtual ICollection<Homework> Homeworks { get; set; }
        public virtual ICollection<CourseContent> CourseContents { get; set; }
        public virtual ICollection<CourseResource> CourseResources { get; set; }
         
        
    }
}
