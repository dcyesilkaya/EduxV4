using System;
using System.Collections.Generic;
using System.Text;

namespace EduxV4.Data
{
    public class BranchCourseContent:BaseEntity
    {
        public string BranchId { get; set; }
        public Branch Branch { get; set; }

        public string CourseContentId { get; set; }
        public CourseContent CourseContent { get; set; }
    }
}
