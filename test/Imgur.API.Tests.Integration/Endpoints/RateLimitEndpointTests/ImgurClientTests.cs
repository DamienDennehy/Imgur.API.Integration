using System.Threading.Tasks;
using Imgur.API.Authentication.Impl;
using Imgur.API.Endpoints.Impl;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// ReSharper disable ExceptionNotDocumented

namespace Imgur.API.Tests.Integration.Endpoints.RateLimitEndpointTests
{
    [TestClass]
    public class ImgurClientTests : TestBase
    {
        [TestMethod]
        [TestCategory("RateLimitEndpoint")]
        public async Task RateLimit_GetRateLimitWithImgurClient_IsValidRateLimit()
        {
            var client = new ImgurClient(ClientId, ClientSecret);
            var endpoint = new RateLimitEndpoint(client);
            var limit = await endpoint.GetRateLimitAsync().ConfigureAwait(false);
            Assert.IsNotNull(limit);
            Assert.IsTrue(limit.ClientLimit > 0);
            Assert.IsTrue(limit.ClientRemaining > 0);
        }

        [TestMethod]
        [TestCategory("RateLimitEndpoint")]
        public async Task RateLimit_GetRateLimitWithImgurClientAndOAuth2Authentication_IsValidRateLimit()
        {
            var client = new ImgurClient(ClientId, ClientSecret, OAuth2Token);

            var endpoint = new RateLimitEndpoint(client);
            var limit = await endpoint.GetRateLimitAsync().ConfigureAwait(false);

            Assert.IsNotNull(limit);
            Assert.IsTrue(limit.ClientLimit > 0);
            Assert.IsTrue(limit.ClientRemaining > 0);
        }
    }
}