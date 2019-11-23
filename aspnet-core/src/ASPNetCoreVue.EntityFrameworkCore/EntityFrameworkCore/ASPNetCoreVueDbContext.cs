using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using ASPNetCoreVue.Authorization.Roles;
using ASPNetCoreVue.Authorization.Users;
using ASPNetCoreVue.MultiTenancy;

namespace ASPNetCoreVue.EntityFrameworkCore
{
    public class ASPNetCoreVueDbContext : AbpZeroDbContext<Tenant, Role, User, ASPNetCoreVueDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public ASPNetCoreVueDbContext(DbContextOptions<ASPNetCoreVueDbContext> options)
            : base(options)
        {
        }
    }
}
