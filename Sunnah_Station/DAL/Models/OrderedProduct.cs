using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class OrderedProduct
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Pid { get; set; }

        // [ForeignKey("Pid")]
        public Product Product { get; set; }

        [Required]
        public int Oid { get; set; }

       // [ForeignKey("Oid")]
        public Order Order { get; set; }
    }
}
