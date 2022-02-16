using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WFM.Models
{
    public class CustomerAddress
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Customer")]
        public int CustomerRefId { get; set; }
        [ForeignKey("Address")]
        public int AddressRefId { get; set; }
    }
}
