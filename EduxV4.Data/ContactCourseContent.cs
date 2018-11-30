using System;
using System.Collections.Generic;
using System.Text;

namespace EduxV4.Data
{
    public class ContactCourseContent:BaseEntity
    {
        public string ContactId { get; set; }
        public Contact Contact { get; set; }

        public string CourseContentId { get; set; }
        public CourseContent CourseContent { get; set; }
    }
}
