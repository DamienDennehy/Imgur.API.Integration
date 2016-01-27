using System.Linq;
using System.Threading.Tasks;
using Imgur.API.Authentication.Impl;
using Imgur.API.Endpoints.Impl;
using Xunit;

// ReSharper disable ExceptionNotDocumented

namespace Imgur.API.Tests.Integration.Endpoints.MemeGenEndpointTests
{
    public class ImgurClientTests : TestBase
    {
        [Fact]
        [Trait("Category", "MemeGenEndpoint")]
        public async Task GetDefaultMemesAsync_Any()
        {
            var client = new ImgurClient(Settings.ClientId, Settings.ClientSecret);
            var endpoint = new MemeGenEndpoint(client);

            var memes = await endpoint.GetDefaultMemesAsync().ConfigureAwait(false);

            Assert.True(memes.Any());
        }
    }
}