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
        public string TenKH { get; set; }
        public int SoDienThoai { get; set; }
    }
}
