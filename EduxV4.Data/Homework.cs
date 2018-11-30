using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EduxV4.Data
{
    public class Homework:BaseEntity
    {
        [Display(Name = "Başlık")]
        [Required]
        public string Title { get; set; }
        [Display(Name = "Açıklama")]
        public string Description { get; set; }
        [Display(Name = "Çözüm Dosyası")]
        public string SolutionFile { get; set; }
        [Display(Name = "Ödev Dosyası")]
        public string HomeworkFile { get; set; }
        [Display(Name = "Başlama tarihi")]
        public DateTime? StartDate { get; set; }
        [Display(Name = "Bitirme tarihi")]
        public DateTime? EndDate { get; set; }

        [Display(Name = "Ders")]
        public string CourseId { get; set; }
        [Display(Name = "Ders")]
        [ForeignKey("CourseId")]
        public Course Course { get; set; }

        public virtual ICollection<BranchHomework> BranchHomeworks { get; set; }
        public virtual ICollection<ContactHomework> ContactHomeworks { get; set; }

    }
}
