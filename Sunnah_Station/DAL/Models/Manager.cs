using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Manager
        {
            [Key]
            public int Id { get; set; }

            [Required]
            public string Name { get; set; }

            [Required]
            public string Address { get; set; }

            [Required]
            [StringLength(20)]
            public string Phone { get; set; }

            [Required]
            [StringLength(100)]
            public string Email { get; set; }

            [Required]
            [StringLength(10)]
            public string Blood { get; set; }

            [Required]
            public string Password { get; set; }

            public byte[] Pic { get; set; }
        

    }
}
