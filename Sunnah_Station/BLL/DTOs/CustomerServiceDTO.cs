using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class CustomerServiceDTO
    {

       
        public int Id { get; set; }

        public int? CustomerId { get; set; }

        public string RatingDescription { get; set; }

        public DateTime? RatingTime { get; set; }
    }
}
