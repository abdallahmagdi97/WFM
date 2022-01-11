using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WFM.Models
{
    public class Meter
    {
        [Key]
        public int Id { get; set; }
        public string Number { get; set; }
        [ForeignKey("Customer")]
        public int CustomerRefId { get; set; }
        public Customer Customer { get; set; }
        public DateTime InstallationDate { get; set; }
    }
}