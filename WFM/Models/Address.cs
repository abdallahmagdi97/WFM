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
        [ForeignKey("Customer")]
<<<<<<< HEAD
        public virtual int CustomerId { get; set; }
=======
        public int CustomerRefId { get; set; }
>>>>>>> 2f2a67bf8dfaf8d1c44e0a5cbb4c4d04404dd9e9
    }
}