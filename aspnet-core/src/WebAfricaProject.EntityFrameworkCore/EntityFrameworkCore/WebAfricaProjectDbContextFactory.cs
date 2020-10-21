using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using WebAfricaProject.Configuration;
using WebAfricaProject.Web;

namespace WebAfricaProject.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class WebAfricaProjectDbContextFactory : IDesignTimeDbContextFactory<WebAfricaProjectDbContext>
    {
        public WebAfricaProjectDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<WebAfricaProjectDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            WebAfricaProjectDbContextConfigurer.Configure(builder, configuration.GetConnectionString(WebAfricaProjectConsts.ConnectionStringName));

            return new WebAfricaProjectDbContext(builder.Options);
        }
    }
}
