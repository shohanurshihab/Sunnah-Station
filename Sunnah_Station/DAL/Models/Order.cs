using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

      
        public int? Cus_Id { get; set; }

        [ForeignKey("Cus_Id")]
        public Customer Customer { get; set; }

       
        public int? Pid { get; set; }

        [ForeignKey("Pid")]
        public Product Product { get; set; }

        [Required]
        [StringLength(20)]
        public string Status { get; set; }

        
        public string Message { get; set; }

        public ICollection<OrderedProduct> OrderedProducts { get; set; }
    }
}
