using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EduxV4.Data
{
    public class District:BaseEntity
    {
        [StringLength(200)]
        [Display(Name = "Ad")]
        public string Name { get; set; }
        [Display(Name = "İlçe")]
        public string CountyId { get; set; }
        [ForeignKey("CountyId")]
        [Display(Name = "İlçe")]
        public County County { get; set; }
        public virtual ICollection<Region> Regions { get; set; }
    }
}
