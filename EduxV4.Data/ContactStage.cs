using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EduxV4.Data
{
    public enum ContactStage
    {
        [Display(Name="Aday")]
        Candidate = 1,
        [Display(Name = "Ön Kayıt")]
        PreRegistration = 2,
        [Display(Name = "Kesin Kayıt")]
        CertainRegistration = 3
    }
}
