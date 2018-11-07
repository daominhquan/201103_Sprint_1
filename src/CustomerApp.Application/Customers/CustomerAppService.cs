using Abp.Application.Services;
using AutoMapper;
using CustomerApp.Models;
using HuflitBigPrj.Customers.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerApp.Customers
{
    public class CustomerAppService : ApplicationService, ICustomerAppService
    {
        private readonly ICustomerManager _customerManager;
        public CustomerAppService(ICustomerManager customerManager)
        {
            _customerManager = customerManager;
        }

        public async Task Create(CreateCustomerInput input)
        {
            Customer output = Mapper.Map<CreateCustomerInput, Customer>(input);
            await _customerManager.Create(output);
        }

        public void Delete(DeleteCustomergInput input)
        {
            _customerManager.Delete(input.Id);
        }

        public GetCustomerOutput GetCustomerById(GetCustomerInput input)
        {
            var getCustomer = _customerManager.GetCustomerById(input.Id);
            GetCustomerOutput output = Mapper.Map<Customer, GetCustomerOutput>(getCustomer);
            return output;
        }

        public IEnumerable<GetCustomerOutput> ListAll()
        {
            var getAll = _customerManager.GetAllList().ToList();
            List<GetCustomerOutput> output = Mapper.Map<List<Customer>, List<GetCustomerOutput>>(getAll);
            return output;
        }

        public void Update(UpdateCustomerInput input)
        {
            Customer output = Mapper.Map<UpdateCustomerInput, Customer>(input);
            _customerManager.Update(output);
        }
    }
}
