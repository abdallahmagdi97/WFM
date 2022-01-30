using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WFM.Models
{
    public class CustomerMeters
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Customer")]
        public int CustomerRefId { get; set; }
        [ForeignKey("Meter")]
        public int MeterRefId { get; set; }
    }
}
