using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EduxV4.Data
{
    public enum CourseResourceType
    {
        [Display(Name = "Ödevler")]
        Homeworks = 1,
        [Display(Name = "Ders Notları")]
        CourseNotes = 2
    }
}
