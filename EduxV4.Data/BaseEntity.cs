using System;
using System.ComponentModel.DataAnnotations;

namespace EduxV4.Data
{
    public class BaseEntity
    { 
        public string Id { get; set; }
        [Display(Name = "Oluşturulma Tarihi")]
        public DateTime CreateDate { get; set; }
        [Display(Name = "Oluşturan Kullanıcı")]
        public string CreatedBy { get; set; }
        [Display(Name = "Güncellenme Tarihi")]
        public DateTime UpdateDate { get; set; }
        [Display(Name = "Güncelleyen Kullanıcı")]
        public string UpdatedBy { get; set; }
        [Display(Name = "IP Adresi")]
        public string IPAddress { get; set; }
    }
}
