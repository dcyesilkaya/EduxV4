using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EduxV4.Data
{
    public class Announcement:BaseEntity
    {
        
            [Display(Name = "Başlık")]
            public string Title { get; set; }
            [Display(Name = "İçerik")]
            public string Content { get; set; }
            [Display(Name = "Yayınlanma Tarihi")]
            public DateTime? PublishDate { get; set; }
            [Display(Name = "Hafta")]
            public int Week { get; set; }

            [Display(Name = "Ders")]
            public string CourseId { get; set; }
            [Display(Name = "Ders")]
            [ForeignKey("CourseId")]
            public Course Course { get; set; }

            public virtual ICollection<Branch> Branches { get; set; }
            [Display(Name = "Kişiler")]
            public virtual ICollection<Contact> Students { get; set; }
            [Display(Name = "Yorumlara İzin Ver")]
            public bool AllowComments { get; set; }

       
    }
}
