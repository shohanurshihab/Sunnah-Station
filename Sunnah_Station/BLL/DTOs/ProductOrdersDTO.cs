using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class ProductOrdersDTO:ProductDTO
    {
        public List<OrderDTO> Orders { get; set; }
        public ProductOrdersDTO() { 
        Orders = new List<OrderDTO>();
        }
    }
}
