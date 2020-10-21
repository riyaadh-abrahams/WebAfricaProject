using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace WebAfricaProject.EntityFrameworkCore
{
    public static class WebAfricaProjectDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<WebAfricaProjectDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<WebAfricaProjectDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
