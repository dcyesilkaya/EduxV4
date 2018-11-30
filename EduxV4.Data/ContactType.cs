using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EduxV4.Data
{
    public enum ContactType
    {
        [Display(Name = "Öğrenci")]
        Student = 1,
        [Display(Name = "Veli")]
        Parent = 2,
        [Display(Name = "Personel")]
        Staff = 3,
        [Display(Name = "Eğitmen")]
        Teacher = 4
    }
}
