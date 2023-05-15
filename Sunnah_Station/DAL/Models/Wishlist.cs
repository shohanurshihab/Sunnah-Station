using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Wishlist
    {
        [Key] 
        public int Id { get; set; }

        [ForeignKey("Customer")]
        public int? CustomerId { get; set; }

        [ForeignKey("Product")]
        public int? ProductId { get; set; }

        public virtual User Customer { get; set; }

        public virtual Product Product { get; set; }




    }
}
