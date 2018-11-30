using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EduxV4.Data
{
    public enum Status
    {
        [Display(Name="Aktif")]
        Active = 1,
        [Display(Name = "Pasif")]
        Passive = 2
    }
}
