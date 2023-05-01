using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Admin
    {
        
            [Key]
            public int Id { get; set; }

            [Required]
            public string Name { get; set; }

            [Required]
            //[EmailAddress]
            public string Email { get; set; }

            [Required]
            public string Address { get; set; }

            [Required]
           // [RegularExpression(@"^[0-9]{10}$")]
            public string Phone { get; set; }

            [Required]
          //  [DataType(DataType.Date)]
            public DateTime Dob { get; set; }

            [Required]
            public string Password { get; set; }

            public byte[] Pic { get; set; }
        


    }
}
