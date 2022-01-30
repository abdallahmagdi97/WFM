using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WFM.Models
{
    public class Ticket
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        [ForeignKey("Area")]
        public int AreaRefId { get; set; }
        [ForeignKey("Address")]
        public int AddressRefId { get; set; }
        [ForeignKey("Customer")]
        public int CustomerRefId { get; set; }
        [ForeignKey("Meter")]
        public int MeterRefId { get; set; }
        [ForeignKey("Tech")]
        public int TechRefId { get; set; }
        [ForeignKey("Status")]
        public int StatusRefId { get; set; }
        public string Description { get; set; }
    }
}
