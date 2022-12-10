using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClimbingInfo.Models
{
    public class Members
    {
        public int ID { get; set; }
        
        [Required]
        [StringLength(15,ErrorMessage ="Please enter your full name using 30 characters or less.")]
        [Column("Name")]
        [Display(Name = "Name")]
        public string name { get; set; }
        
        [RegularExpression("^[a-zA-Z]*$", ErrorMessage = "Only alphabetic letters are allowed.")]
        [Column("Gender")]
        /*[Display(gender = "Gender")]*/
        public string gender { get; set; } = "prefer not to disclose";
        
        [StringLength(50, ErrorMessage ="Please enter your address using 50 characters or less.")]
       /* [Display(address = "Address")]*/
        public string address { get; set; }
        
        [StringLength(30, ErrorMessage ="Please enter the city name using 30 characters or less.")]
       /* [Display(city = "City")]*/
        public string city { get; set; }
        
        [StringLength(2, ErrorMessage ="Please enter the State using 2 characters.")]
        public string state { get; set; }
        
        [StringLength(10, ErrorMessage ="Zipcode has a maximum length of 10 numbers.")]
        public string zip { get; set; }
        
        [Required(ErrorMessage = "Email is required")]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Incorrect Email Format")]
        public string email { get; set; }
        
        [ConcurrencyCheck]
        public string cell { get; set; }

        public int ExperienceId { get; set; }
        public Experience Experience { get; set; }

        /*  [Display(MembersID = "Members ID")]*/
        public int GearId { get; set; }
        public Gear Gear { get; set; }


    }
}
