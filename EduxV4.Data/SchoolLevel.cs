using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EduxV4.Data
{
    public class SchoolLevel:BaseEntity
    {
        [Display(Name="Ad")]
        public string Name { get; set; }
        [Display(Name="Kampüs")]
        public string CampusId { get; set; }
        [ForeignKey("CampusId")]
        [Display(Name = "Kampüs")]
        public Campus Campus { get; set; }
        public virtual ICollection<ClassLevel> ClassLevels { get; set; }
    }
}
