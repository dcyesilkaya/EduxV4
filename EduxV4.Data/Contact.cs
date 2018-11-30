using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EduxV4.Data
{
    public class Contact:BaseEntity
    {
        public Contact()
        {
            Activities = new HashSet<Activity>();
            ActivitiesFor = new HashSet<Activity>();
            StaffActivities = new HashSet<Activity>();
        }
        [Display(Name ="Tam Ad")]
        public string FullName { get { return FirstName + " " + LastName; } }
        [StringLength(200)]
        [Display(Name = "Ad")]
        public string FirstName { get; set; }
        [StringLength(200)]
        [Display(Name = "Soyad")]
        public string LastName { get; set; }
        [Display(Name = "Cinsiyet")]
        public Gender Gender { get; set; }
        [StringLength(11)]
        [Display(Name = "TC Kimlik No")]
        public string IdentityNumber { get; set; }
        [Display(Name = "Sınıf Seviyesi")]
        public string ClassLevelId { get; set; }
        [ForeignKey("ClassLevelId")]
        [Display(Name = "Sınıf Seviyesi")]
        public ClassLevel ClassLevel { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Doğum Tarihi")]
        public DateTime? BirthDate { get; set; }
        [StringLength(200)]
        [Display(Name = "Doğum Yeri")]
        public string BirthPlace { get; set; }
        [StringLength(200)]
        [Display(Name = "Sabit Telefon")]
        public string LandingPhone { get; set; }
        [StringLength(200)]
        [Display(Name = "Mobil Telefon")]
        public string MobilePhone { get; set; }
        [StringLength(200)]
        [Display(Name = "E-posta")]
        public string Email { get; set; }
        [Display(Name = "Notlar")]
        public string Notes { get; set; }
        [Display(Name = "Ülke")]
        public string CountryId { get; set; }
        [ForeignKey("CountryId")]
        [Display(Name = "Ülke")]
        public Country Country { get; set; }
        [Display(Name = "Şehir")]
        public string CityId { get; set; }
        [ForeignKey("CityId")]
        [Display(Name = "ŞEhir")]
        public City City { get; set; }
        [Display(Name = "İlçe")]
        public string CountyId { get; set; }
        [Display(Name = "İlçe")]
        [ForeignKey("CountyId")]
        public County County { get; set; }
        [Display(Name = "Mahalle")]
        public string DistrictId { get; set; }
        [Display(Name = "Mahalle")]
        [ForeignKey("DistrictId")]
        public District District { get; set; }
        [Display(Name = "Semt")]
        public string RegionId { get; set; }
        [ForeignKey("RegionId")]
        [Display(Name = "Semt")]
        public Region Region { get; set; }
        [StringLength(200)]
        [Display(Name = "Posta Kodu")]
        public string ZipCode { get; set; }
        [StringLength(4000)]
        [Display(Name = "Adres")]
        public string Address { get; set; }
        [Display(Name = "Anne")]
        public string MotherId { get; set; }
        [ForeignKey("MotherId")]
        [Display(Name = "Anne")]
        public Contact Mother { get; set; }
        [Display(Name = "Baba")]
        public string FatherId { get; set; }
        [ForeignKey("FatherId")]
        [Display(Name = "Baba")]
        public Contact Father { get; set; }
        [Display(Name = "Velisi")]
        public string ParentId { get; set; }
        [Display(Name = "Velisi")]
        [ForeignKey("ParentId")]
        public Contact Parent { get; set; }
        [Display(Name = "Meslek")]
        public string OccupationId { get; set; }
        [Display(Name = "Meslek")]
        public Occupation Occupation { get; set; }
        [Display(Name = "Kişi Türü")]
        public ContactType ContactType { get; set; }
        [Display(Name = "Aşama")]
        public ContactStage ContactStage { get; set; }
        [Display(Name = "Bu Kişiyle Yapılan Görüşmeler")]
        public virtual ICollection<Activity> Activities { get; set; }
        [Display(Name = "Bu Kişinin Yaptığı Görüşmeler")]
        public virtual ICollection<Activity> StaffActivities { get; set; }
        [Display(Name = "Bu Kişi İçin Yapılan Görüşmeler")]
        public virtual ICollection<Activity> ActivitiesFor { get; set; }
        [Display(Name = "Aile")]
        public string FamilyId { get; set; }
        [ForeignKey("FamilyId")]
        [Display(Name = "Aile")]
        public Family Family { get; set; }
        [Display(Name = "Ailedeki Rolü")]
        public FamilyRole FamilyRole { get; set; }

        public virtual ICollection<ContactHomework> ContactHomeworks { get; set; }
        public virtual ICollection<ContactCourseContent> ContactCourseContents { get; set; }
    }
}
