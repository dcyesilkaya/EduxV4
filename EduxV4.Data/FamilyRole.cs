using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EduxV4.Data
{
    public enum FamilyRole
    {
        [Display(Name = "Anne")]
        Mother = 1,
        [Display(Name = "Baba")]
        Father = 2,
        [Display(Name = "Erkek Kardeş")]
        Brother = 3,
        [Display(Name = "Kız Kardeş")]
        Sister = 4,
        [Display(Name = "Diğer Ebeveyn")]
        OtherParent = 5
    }
}
