using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WFM.Models
{
    public class Tech
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Skill> Skills { get; set; }
        public string NationalID { get; set; }
        public string Mobile { get; set; }
        public List<Area> Area { get; set; }
    }
}