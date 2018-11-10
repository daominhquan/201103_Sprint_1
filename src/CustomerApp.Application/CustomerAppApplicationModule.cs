using System.Reflection;
using Abp.Authorization;
using Abp.Authorization.Roles;
using Abp.Authorization.Users;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Modules;
using CustomerApp.Authorization.Roles;
using CustomerApp.Authorization.Users;
using CustomerApp.Roles.Dto;
using CustomerApp.Users.Dto;
using System.Reflection;
using Abp.AutoMapper;
using HuflitBigPrj.Customers.DTO;
using CustomerApp.Models;

namespace CustomerApp
{
    [DependsOn(typeof(CustomerAppCoreModule), typeof(AbpAutoMapperModule))]
    public class CustomerAppApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Modules.AbpAutoMapper().Configurators.Add(mapper =>
            {
                mapper.CreateMap<CreateCustomerInput, Customer>().ReverseMap();
                mapper.CreateMap<GetCustomerOutput, Customer>().ReverseMap();
                mapper.CreateMap<GetCustomerInput, Customer>().ReverseMap();
                mapper.CreateMap<DeleteCustomergInput, Customer>().ReverseMap();
                mapper.CreateMap<UpdateCustomerInput, Customer>().ReverseMap();
            }); 
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            // TODO: Is there somewhere else to store these, with the dto classes
            Configuration.Modules.AbpAutoMapper().Configurators.Add(cfg =>
            {
                // Role and permission
                cfg.CreateMap<Permission, string>().ConvertUsing(r => r.Name);
                cfg.CreateMap<RolePermissionSetting, string>().ConvertUsing(r => r.Name);

                cfg.CreateMap<CreateRoleDto, Role>().ForMember(x => x.Permissions, opt => opt.Ignore());
                cfg.CreateMap<RoleDto, Role>().ForMember(x => x.Permissions, opt => opt.Ignore());
                
                cfg.CreateMap<UserDto, User>();
                cfg.CreateMap<UserDto, User>().ForMember(x => x.Roles, opt => opt.Ignore());

                cfg.CreateMap<CreateUserDto, User>();
                cfg.CreateMap<CreateUserDto, User>().ForMember(x => x.Roles, opt => opt.Ignore());
            });
        }
    }
}
