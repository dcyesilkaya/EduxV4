using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EduxV4.Data
{
    public class Region:BaseEntity
    {
        [StringLength(200)]
        public string Name { get; set; }
        public string DistrictId { get; set; }
        [ForeignKey("DistrictId")]
        public District District { get; set; }        
    }
}
