using System.Linq;
using CustomerApp.EntityFramework;
using CustomerApp.MultiTenancy;

namespace CustomerApp.Migrations.SeedData
{
    public class DefaultTenantCreator
    {
        private readonly CustomerAppDbContext _context;

        public DefaultTenantCreator(CustomerAppDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateUserAndRoles();
        }

        private void CreateUserAndRoles()
        {
            //Default tenant

            var defaultTenant = _context.Tenants.FirstOrDefault(t => t.TenancyName == Tenant.DefaultTenantName);
            if (defaultTenant == null)
            {
                _context.Tenants.Add(new Tenant {TenancyName = Tenant.DefaultTenantName, Name = Tenant.DefaultTenantName});
                _context.SaveChanges();
            }
        }
    }
}
