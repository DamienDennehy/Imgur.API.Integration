using System.Linq;
using System.Threading.Tasks;
using Imgur.API.Authentication.Impl;
using Imgur.API.Endpoints.Impl;
using Xunit;

// ReSharper disable ExceptionNotDocumented

namespace Imgur.API.Tests.Integration.Endpoints.MemeGenEndpointTests
{
    public class MashapeClientTests : TestBase
    {
        [Fact]
        [Trait("Category", "MemeGenEndpoint")]
        public async Task GetDefaultMemesAsync_Any()
        {
            var client = new MashapeClient(Settings.ClientId, Settings.MashapeKey);
            var endpoint = new MemeGenEndpoint(client);

            var memes = await endpoint.GetDefaultMemesAsync().ConfigureAwait(false);

            Assert.True(memes.Any());
        }
    }
}