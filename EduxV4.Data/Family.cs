using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EduxV4.Data
{
    public class Family:BaseEntity
    {
        public Family()
        {
            Members = new HashSet<Contact>();
        }
        [Display(Name = "Aile Adı")]
        public string Name { get; set; }
        public virtual ICollection<Contact> Members { get; set; }
    }
}
