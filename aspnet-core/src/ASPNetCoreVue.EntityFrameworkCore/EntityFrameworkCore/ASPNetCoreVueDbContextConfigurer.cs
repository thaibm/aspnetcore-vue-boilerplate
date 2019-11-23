using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace ASPNetCoreVue.EntityFrameworkCore
{
    public static class ASPNetCoreVueDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<ASPNetCoreVueDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<ASPNetCoreVueDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
