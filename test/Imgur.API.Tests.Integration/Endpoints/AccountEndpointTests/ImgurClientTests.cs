using System;
using System.Threading.Tasks;
using Imgur.API.Authentication.Impl;
using Imgur.API.Endpoints.Impl;
using Xunit;

// ReSharper disable ExceptionNotDocumented

namespace Imgur.API.Tests.Integration.Endpoints.AccountEndpointTests
{
    public class ImgurClientTests : TestBase
    {
        [Fact]
        [Trait("Category", "AccountEndpoint")]
        public async Task GetAccountAsync_WithUsername_Equal()
        {
            var client = new ImgurClient(Settings.ClientId);
            var endpoint = new AccountEndpoint(client);

            var account = await endpoint.GetAccountAsync("sarah").ConfigureAwait(false);

            Assert.True("sarah".Equals(account.Url, StringComparison.OrdinalIgnoreCase));
        }
    }
}