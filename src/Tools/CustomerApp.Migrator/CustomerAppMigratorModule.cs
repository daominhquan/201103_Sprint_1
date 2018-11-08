using System.Data.Entity;
using System.Reflection;
using Abp.Modules;
using CustomerApp.EntityFramework;

namespace CustomerApp.Migrator
{
    [DependsOn(typeof(CustomerAppDataModule))]
    public class CustomerAppMigratorModule : AbpModule
    {
        public override void PreInitialize()
        {
            Database.SetInitializer<CustomerAppDbContext>(null);

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}