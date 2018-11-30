using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EduxV4.Data
{
    public class ActivitySource:BaseEntity
    {
        [Display(Name="Ad")]
        public string Name { get; set; }
        [Display(Name="Üst Görüşme Kaynağı")]
        public string ParentActivitySourceId { get; set; }
        [ForeignKey("ParentActivitySourceId")]
        [Display(Name = "Üst Görüşme Kaynağı")]
        public ActivitySource ParentActivitySource { get; set; }
        public virtual ICollection<ActivitySource> ChildActivitySources { get; set; }
    }
}
