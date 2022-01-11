using System.ComponentModel.DataAnnotations;

namespace WFM.Models
{
    public class Area
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}