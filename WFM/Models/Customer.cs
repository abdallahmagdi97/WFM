using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WFM.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public string NationalID { get; set; }
        public string Mobile { get; set; }
<<<<<<< HEAD
        public List<Address> Addresses { get; set; }
=======
        public DateTime CreationDate { get; set; }
>>>>>>> 2f2a67bf8dfaf8d1c44e0a5cbb4c4d04404dd9e9
    }
}
