using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ClimbingInfo.Models
{
    public class Gear
    {
        public int GearId { get; set; }
        [Required]
        public string SetupName { get; set; }
        public string Shoes { get; set; }
        public string Harness { get; set; }
        public string Chalk_Bag { get; set; }
    }
}
