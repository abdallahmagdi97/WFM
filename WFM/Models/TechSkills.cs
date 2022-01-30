using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WFM.Models
{
    public class TechSkills
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Tech")]
        public int TechRefId { get; set; }
        [ForeignKey("Skill")]
        public int SkillRefId { get; set; }
    }
}
