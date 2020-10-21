using System.Threading.Tasks;
using WebAfricaProject.Models.TokenAuth;
using WebAfricaProject.Web.Controllers;
using Shouldly;
using Xunit;

namespace WebAfricaProject.Web.Tests.Controllers
{
    public class HomeController_Tests: WebAfricaProjectWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}