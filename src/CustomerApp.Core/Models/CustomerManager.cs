using Abp.Domain.Repositories;
using Abp.Domain.Services;
using Abp.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerApp.Models
{
    public class CustomerManager : DomainService, ICustomerManager
    {
        private readonly IRepository<Customer> _repositoryKhachHang;
        public CustomerManager(IRepository<Customer> repositoryKhachHang)
        {
            _repositoryKhachHang = repositoryKhachHang;
        }

        public async Task<Customer> Create(Customer entity)
        {
            var khachhang = _repositoryKhachHang.FirstOrDefault(x => x.Id == entity.Id);
            if (khachhang != null)
            {
                throw new UserFriendlyException("Already Exist");
            }
            else
            {
                return await _repositoryKhachHang.InsertAsync(entity);
            }
        }

        public void Delete(int id)
        {
            var khachhang = _repositoryKhachHang.FirstOrDefault(x => x.Id == id);
            if (khachhang != null)
            {
                throw new UserFriendlyException("No Data Found");
            }
            else
            {
                _repositoryKhachHang.Delete(khachhang);
            }

        }

        public IEnumerable<Customer> GetAllList()
        {
            return _repositoryKhachHang.GetAll();
        }

        public Customer GetCustomerById(int id)
        {
            return _repositoryKhachHang.Get(id);
        }

        public void Update(Customer entity)
        {
            _repositoryKhachHang.Update(entity);
        }
    }
}
