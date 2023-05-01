using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
            
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int Quantity { get; set; }

        
        public int? Cid { get; set; }

        [ForeignKey("Cid")]
        public Category Category { get; set; }

        public byte[] Pic { get; set; }

        public ICollection<Feedback> Feedbacks { get; set; }

        public ICollection<OrderedProduct> OrderedProducts { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
