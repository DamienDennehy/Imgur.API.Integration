using System.Threading.Tasks;
using Imgur.API.Authentication.Impl;
using Imgur.API.Endpoints.Impl;
using Xunit;

// ReSharper disable ExceptionNotDocumented

namespace Imgur.API.Tests.Integration.Endpoints.AccountEndpointImageTests
{
    public class MashapeClientTests : TestBase
    {
        [Fact]
        [Trait("Category", "AccountEndpointImage")]
        public async Task GetImageAsync_NotNull()
        {
            var client = new MashapeClient(Settings.ClientId, Settings.ClientSecret, Settings.MashapeKey);
            var endpoint = new AccountEndpoint(client);

            var image = await endpoint.GetImageAsync("ra06GZN", "sarah").ConfigureAwait(false);

            Assert.NotNull(image);
        }
    }
}