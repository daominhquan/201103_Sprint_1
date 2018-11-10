using System.Data.Common;
using System.Data.Entity;
using Abp.Zero.EntityFramework;
using CustomerApp.Authorization.Roles;
using CustomerApp.Authorization.Users;
using CustomerApp.Models;
using CustomerApp.MultiTenancy;

namespace CustomerApp.EntityFramework
{
    public class CustomerAppDbContext : AbpZeroDbContext<Tenant, Role, User>
    {
        //TODO: Define an IDbSet for your Entities...

        /* NOTE: 
         *   Setting "Default" to base class helps us when working migration commands on Package Manager Console.
         *   But it may cause problems when working Migrate.exe of EF. If you will apply migrations on command line, do not
         *   pass connection string name to base classes. ABP works either way.
         */
        public DbSet<Customer> Customers { get; set; }

        public CustomerAppDbContext()
            : base("Default")
        {

        }

        /* NOTE:
         *   This constructor is used by ABP to pass connection string defined in CustomerAppDataModule.PreInitialize.
         *   Notice that, actually you will not directly create an instance of CustomerAppDbContext since ABP automatically handles it.
         */
        public CustomerAppDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        //This constructor is used in tests
        public CustomerAppDbContext(DbConnection existingConnection)
         : base(existingConnection, false)
        {

        }

        public CustomerAppDbContext(DbConnection existingConnection, bool contextOwnsConnection)
         : base(existingConnection, contextOwnsConnection)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }
    }
}
