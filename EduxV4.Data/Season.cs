using System;
using System.Collections.Generic;
using System.Text;

namespace EduxV4.Data
{
    public class Season:BaseEntity
    {
        public string Name { get; set; }
        public virtual ICollection<CourseResource> CourseResources { get; set; }
    }
}
