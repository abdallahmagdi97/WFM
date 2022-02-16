using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WFM.Models
{
    public class TechAreas
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Tech")]
        public int TechRefId { get; set; }
        [ForeignKey("Area")]
        public int AreaRefId { get; set; }
    }
}
