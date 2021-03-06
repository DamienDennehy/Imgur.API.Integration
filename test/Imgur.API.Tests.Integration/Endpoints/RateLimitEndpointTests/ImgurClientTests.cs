﻿using System.Threading.Tasks;
using Imgur.API.Authentication;
using Imgur.API.Endpoints;
using Xunit;

// ReSharper disable ExceptionNotDocumented

namespace Imgur.API.Tests.Integration.Endpoints.RateLimitEndpointTests
{
    public class ImgurClientTests : TestBase
    {
        [Fact]
        [Trait("Category", "RateLimitEndpoint")]
        public async Task RateLimit_GetRateLimitWithImgurClient_IsValidRateLimit()
        {
            var client = new ImgurClient(Settings.ClientId);
            var endpoint = new RateLimitEndpoint(client);
            var limit = await endpoint.GetRateLimitAsync().ConfigureAwait(false);
            Assert.NotNull(limit);
            Assert.True(limit.ClientLimit > 0);
            Assert.True(limit.ClientRemaining > 0);
        }

        [Fact]
        [Trait("Category", "RateLimitEndpoint")]
        public async Task RateLimit_GetRateLimitWithImgurClientAndOAuth2Authentication_IsValidRateLimit()
        {
            var client = new ImgurClient(Settings.ClientId, OAuth2Token);

            var endpoint = new RateLimitEndpoint(client);
            var limit = await endpoint.GetRateLimitAsync().ConfigureAwait(false);

            Assert.NotNull(limit);
            Assert.True(limit.ClientLimit > 0);
            Assert.True(limit.ClientRemaining > 0);
        }
    }
}