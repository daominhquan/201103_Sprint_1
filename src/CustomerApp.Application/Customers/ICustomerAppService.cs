using Abp.Application.Services;
using HuflitBigPrj.Customers.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerApp.Customers
{
    public interface ICustomerAppService : IApplicationService
    {
        IEnumerable<GetCustomerOutput> ListAll();
        Task Create(CreateCustomerInput input);
        void Update(UpdateCustomerInput input);
        void Delete(DeleteCustomergInput input);
        GetCustomerOutput GetCustomerById(GetCustomerInput input);
    }
}
