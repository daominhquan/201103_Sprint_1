using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuflitBigPrj.Customers.DTO
{
    public class CreateCustomerInput
    {
        public DateTime CreationTime { get; set; }
        public string CustomerName { get; set; }
        public int PhoneNumber { get; set; }
    }
}
