using System.Threading.Tasks;
using Imgur.API.Authentication;
using Imgur.API.Endpoints;
using Xunit;

// ReSharper disable ExceptionNotDocumented

namespace Imgur.API.Tests.Integration.Endpoints.RateLimitEndpointTests
{
    public class MashapeClientTests : TestBase
    {
        [Fact]
        [Trait("Category", "RateLimitEndpoint")]
        public async Task RateLimit_GetRateLimitWithMashapeClient_IsValidRateLimit()
        {
            var client = new MashapeClient(Settings.ClientId, Settings.MashapeKey);
            var endpoint = new RateLimitEndpoint(client);
            var limit = await endpoint.GetRateLimitAsync().ConfigureAwait(false);
            Assert.NotNull(limit);
            Assert.True(limit.ClientLimit > 0);
            Assert.True(limit.ClientRemaining > 0);
        }

        [Fact]
        [Trait("Category", "RateLimitEndpoint")]
        public async Task RateLimit_GetRateLimitWithMashapeClientAndOAuth2Authentication_IsValidRateLimit()
        {
            var client = new MashapeClient(Settings.ClientId, Settings.MashapeKey, OAuth2Token);

            var endpoint = new RateLimitEndpoint(client);
            var limit = await endpoint.GetRateLimitAsync().ConfigureAwait(false);

            Assert.NotNull(limit);
            Assert.True(limit.ClientLimit > 0);
            Assert.True(limit.ClientRemaining > 0);
        }
    }
}