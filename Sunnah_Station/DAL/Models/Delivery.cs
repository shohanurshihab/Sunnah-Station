using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Delivery
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Order")]
        public int? OrderId { get; set; }


        public int TrackingNo { get; set; }

        [Required]
        public string Carrier { get; set; }
        public DateTime? DeliveryDate { get; set; }

        public virtual Order Order { get; set; }

    }
}
