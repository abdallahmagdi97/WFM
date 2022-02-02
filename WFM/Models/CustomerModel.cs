using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WFM.Models
{
    public class CustomerModel 
    {
        public Customer Customer { get; set; }
        public List<Address> Addresses { get; set; }
    }
}
