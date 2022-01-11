using System.ComponentModel.DataAnnotations;

namespace WFM.Models
{
    public class Status
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}