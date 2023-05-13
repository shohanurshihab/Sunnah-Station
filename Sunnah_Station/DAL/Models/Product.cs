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
       
        [ForeignKey("Category")]  
        public int? CategoryId { get; set; }

        public string Image { get; set; }

     
        public virtual Category Category { get; set; }

        public virtual ICollection<Order> Orders { get; set;}

        public Product() { 
        Orders = new List<Order>();
        }
    }
}
