using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EduxV4.Data
{
    public class Campus:BaseEntity
    {
        [Display(Name = "Ad")]
        public string Name { get; set; }
        public string SchoolId { get; set; }
        [ForeignKey("SchoolId")]
        public School School { get; set; }
        public virtual ICollection<SchoolLevel> SchoolLevels { get; set; }
    }
}
