using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using ASPNetCoreVue.Configuration;
using ASPNetCoreVue.Web;

namespace ASPNetCoreVue.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class ASPNetCoreVueDbContextFactory : IDesignTimeDbContextFactory<ASPNetCoreVueDbContext>
    {
        public ASPNetCoreVueDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<ASPNetCoreVueDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            ASPNetCoreVueDbContextConfigurer.Configure(builder, configuration.GetConnectionString(ASPNetCoreVueConsts.ConnectionStringName));

            return new ASPNetCoreVueDbContext(builder.Options);
        }
    }
}
