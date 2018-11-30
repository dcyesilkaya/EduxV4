using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EduxV4.Data
{
    public class Country:BaseEntity
    {
        [StringLength(200)]
        [Display(Name = "Ad")]
        public string Name { get; set; }
        public virtual ICollection<City> Cities { get; set; }
    }
}
