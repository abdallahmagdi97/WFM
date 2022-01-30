using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WFM.Models
{
    public class Address
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
        [ForeignKey("Area")]
        public int AreaRefId { get; set; }
        public float Longitude { get; set; }
        public float Latitude { get; set; }
    }
}