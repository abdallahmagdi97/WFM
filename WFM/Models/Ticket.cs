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
        public Area Area { get; set; }
        [ForeignKey("Area")]
        public int AreaRefId { get; set; }
        public Address Address { get; set; }
        [ForeignKey("Address")]
        public int AddressRefId { get; set; }
        public Customer Customer { get; set; }
        [ForeignKey("Customer")]
        public int CustomerRefId { get; set; }
        public Meter Meter { get; set; }
        [ForeignKey("Meter")]
        public int MeterRefId { get; set; }
        public List<Skill> Skills { get; set; }
        public Tech Tech { get; set; }
        [ForeignKey("Tech")]
        public int TechRefId { get; set; }
        public Status Status { get; set; }
        [ForeignKey("Status")]
        public int StatusRefId { get; set; }
        public string Description { get; set; }
    }
}
