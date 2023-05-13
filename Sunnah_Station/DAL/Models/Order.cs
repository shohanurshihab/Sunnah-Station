using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DAL.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        
        [ForeignKey("Customer")]
        public int? CustomerId { get; set; }

        [ForeignKey("Product")]
        public int? ProductId { get; set; }

        [Required]
        [StringLength(20)]
        public string Status { get; set; }

        
        public User Customer { get; set; }

        public Product Product { get; set; }
        
    }
}
