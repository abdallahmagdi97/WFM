using System.ComponentModel.DataAnnotations;

namespace WFM.Models
{
    public class Skill
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}