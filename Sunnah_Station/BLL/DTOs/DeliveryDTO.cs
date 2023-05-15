using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class DeliveryDTO
    {
        
        public int Id { get; set; }
        
        public int? OrderId { get; set; }

        public int TrackingNo { get; set; }
        
        public string Carrier { get; set; }

        public DateTime? DeliveryDate { get; set; }

     
    }
}
