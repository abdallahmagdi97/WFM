using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WFM.Models
{
    public class Tech
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string NationalID { get; set; }
        public string Mobile { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        [NotMapped]
        public int[] Skills { get; set; }
        [NotMapped]
        public int[] Areas { get; set; }
    }
}