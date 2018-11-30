using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EduxV4.Data
{
    public class County:BaseEntity
    {
        [StringLength(200)]
        [Display(Name="İlçe Adı")]
        public string Name { get; set; }
        [Display(Name = "Şehir")]
        public string CityId { get; set; }
        [ForeignKey("CityId")]
        [Display(Name = "Şehir")]
        public City City { get; set; }
        public virtual ICollection<District> Districts { get; set; }
    }
}
