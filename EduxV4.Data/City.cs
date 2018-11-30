using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EduxV4.Data
{
    public class City:BaseEntity
    {
        [StringLength(200)]
        [Display(Name ="Ad")]
        public string Name { get; set; }
        [Display(Name = "Ülke")]
        public string CountryId { get; set; }
      
        [ForeignKey("CountryId")]
        [Display(Name = "Ülke")]
        public Country Country { get; set; }
        public virtual ICollection<County> Counties { get; set; }
    }
}
