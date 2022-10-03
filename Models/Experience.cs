using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ClimbingInfo.Models
{
    public class Experience
    {
        public int ID { get; set; }
        [Required]
        [Range(0,150, ErrorMessage="Enter years between 0-150.")]
        public int years { get; set; }
        [StringLength(50,ErrorMessage ="Please enter how often you plan to climb.")]
        public string freq { get; set; }
        [Required]
        public int MembersID { get; set; }
        public Members Members { get; set; }
    }
}
