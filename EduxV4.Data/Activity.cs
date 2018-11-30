using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduxV4.Data
{
    public class Activity : BaseEntity
    {
        [Display(Name = "Bizden İlgili")]
        public string StaffId { get; set; }
        
        [Display(Name = "Bizden İlgili")]
        public Contact Staff { get; set; }
        [Display(Name = "Görüşme Tarihi")]
        public DateTime ActivityDate { get; set; }
        [Display(Name = "Geldiği Okul")]
        [StringLength(200)]
        public string OldSchool { get; set; }
        [Display(Name = "Kayıt Yaptıracağı Okul Türü")]
        public string SchoolLevelId { get; set; }
        [ForeignKey("SchoolLevelId")]
        [Display(Name = "Kayıt Yaptıracağı Okul Türü")]
        public SchoolLevel SchoolLevel { get; set; }
        [Display(Name = "Kayıt Yaptıracağı Kampüs")]
        public string CampusId { get; set; }
        [Display(Name = "Kayıt Yaptıracağı Kampüs")]
        [ForeignKey("CampusId")]
        public Campus Campus { get; set; }
        [Display(Name = "Kayıt Yaptıracağı Sınıf Seviyesi")]
        public string ClassLevelId { get; set; }
        [Display(Name = "Kayıt Yaptıracağı Sınıf Seviyesi")]
        [ForeignKey("ClassLevelId")]
        public ClassLevel ClassLevel { get; set; }
        [Display(Name = "Görüşme Tipi")]
        public string ActivityTypeId { get; set; }
        [ForeignKey("ActivityTypeId")]
        [Display(Name = "Görüşme Tipi")]
        public ActivityType ActivityType { get; set; }
        [Display(Name = "Kaynak")]
        public string ActivitySourceId { get; set; }
        [ForeignKey("ActivitySourceId")]
        [Display(Name = "Kaynak")]
        public ActivitySource ActivitySource { get; set; }
        [Display(Name = "Durum")]
        public string ActivityStatusId { get; set; }
        [ForeignKey("ActivityStatusId")]
        [Display(Name = "Durum")]
        public ActivityStatus ActivityStatus { get; set; }
        [Display(Name = "Olumluluk")]
        public string PositivenessId { get; set; }
        [Display(Name = "Olumluluk")]
        [ForeignKey("PositivenessId")]
        public Positiveness Positiveness { get; set; }
        [Display(Name = "Sonraki Adım")]
        public string ActivityNextStepId { get; set; }
        [ForeignKey("ActivityNextStepId")]
        [Display(Name = "Sonraki Adım")]
        public ActivityNextStep ActivityNextStep { get; set; }
        [Display(Name = "Randevu Tarihi")]
        public DateTime? AppointmentDate { get; set; }
        [Display(Name ="Notlar")]
        public string Notes { get; set; }
        [Display(Name = "Görüşülen Kişi")]
        public string ContactId { get; set; }
     
        [Display(Name = "Görüşülen Kişi")]
        public Contact Contact { get; set; }
        [Display(Name = "Görüşme Kim İçin?")]
        public string ForContactId { get; set; }
        [Display(Name = "Görüşme Kim İçin?")]
        public Contact ForContact { get; set; }

    }
}
    
