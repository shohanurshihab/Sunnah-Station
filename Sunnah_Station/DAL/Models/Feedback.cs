using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Feedback
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(500)]
        public string Comment { get; set; }

        public int? Pid { get; set; }

        [ForeignKey("Pid")]
        public Product Product { get; set; }

        public int? Cus_Id { get; set; }

        [ForeignKey("Cus_Id")]
        public Customer Customer { get; set; }
    }


}
