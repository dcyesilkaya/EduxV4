using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EduxV4.Data
{
    public class School:BaseEntity
    {
        [Display(Name = "Ad")]
        public string Name { get; set; }
        public virtual ICollection<Campus> Campuses { get; set; }
    }
}
