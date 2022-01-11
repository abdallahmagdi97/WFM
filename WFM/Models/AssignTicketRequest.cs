using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WFM.Models
{
    public class AssignTicketRequest
    {
        [Key]
        public int Id { get; set; }
        public Ticket Ticket { get; set; }
        [ForeignKey("Ticket")]
        public int TicketRefId { get; set; }
        public Tech Tech { get; set; }
        [ForeignKey("Tech")]
        public int TechRefId { get; set; }
        public bool IsApprovedByTech { get; set; }
        public bool IsForceAssigned { get; set; }
    }
}
