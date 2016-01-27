using System.Threading.Tasks;
using Imgur.API.Authentication.Impl;
using Imgur.API.Endpoints.Impl;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// ReSharper disable ExceptionNotDocumented

namespace Imgur.API.Tests.Integration.Endpoints.RateLimitEndpointTests
{
    [TestClass]
    public class MashapeClientTests : TestBase
    {
        [TestMethod]
        [TestCategory("RateLimitEndpoint")]
        public async Task RateLimit_GetRateLimitWithMashapeClient_IsValidRateLimit()
        {
            var client = new MashapeClient(Settings.ClientId, Settings.ClientSecret, Settings.MashapeKey);
            var endpoint = new RateLimitEndpoint(client);
            var limit = await endpoint.GetRateLimitAsync().ConfigureAwait(false);
            Assert.IsNotNull(limit);
            Assert.IsTrue(limit.ClientLimit > 0);
            Assert.IsTrue(limit.ClientRemaining > 0);
        }

        [TestMethod]
        [TestCategory("RateLimitEndpoint")]
        public async Task RateLimit_GetRateLimitWithMashapeClientAndOAuth2Authentication_IsValidRateLimit()
        {
            var client = new MashapeClient(Settings.ClientId, Settings.ClientSecret, Settings.MashapeKey, OAuth2Token);

            var endpoint = new RateLimitEndpoint(client);
            var limit = await endpoint.GetRateLimitAsync().ConfigureAwait(false);

            Assert.IsNotNull(limit);
            Assert.IsTrue(limit.ClientLimit > 0);
            Assert.IsTrue(limit.ClientRemaining > 0);
        }
    }
}