using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class WishlistDTO
    {
        public int Id { get; set; }
            
           
        public int? CustomerId { get; set; }

        public int? ProductId { get; set; }
    }
}
