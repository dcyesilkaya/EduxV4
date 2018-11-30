using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EduxV4.Data
{
    public class CourseResource:BaseEntity
    {
        [Display(Name="Başlık")]
        public string Title { get; set; }
        [Display(Name ="Açıklama")]
        public string Description { get; set; }
        [Display(Name = "Sezon")]
        public string SeasonId { get; set; }
        [Display(Name ="Sezon")]
        [ForeignKey("SeasonId")]
        public Season Season { get; set; }
        [Display(Name ="Ders Kaynak Türü")]
        public CourseResourceType CourseResourceType { get; set; }
        [Display(Name ="Ders")]
        public string CourseId { get; set; }
        [ForeignKey("CourseId")]
        [Display(Name = "Ders")]
        public Course Course { get; set; }

        [Display(Name = "Şube")]
        public string BranchId { get; set; }
        [ForeignKey("BranchId")]
        [Display(Name = "Şube")]
        public Branch Branch { get; set; }
        [Display(Name = "Durum")]
        public Status Status { get; set; }
    }
}
