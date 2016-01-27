using System.Threading.Tasks;
using Imgur.API.Authentication.Impl;
using Imgur.API.Endpoints.Impl;
using Xunit;

// ReSharper disable ExceptionNotDocumented

namespace Imgur.API.Tests.Integration.Endpoints.OAuth2EndpointTests
{
    public class MashapeClientTests : TestBase
    {
        [Fact]
        [Trait("Category", "OAuth2Endpoint")]
        public async Task GetTokenByCodeAsync_SetCodeInvalid_ThrowsImgurException()
        {
            var authentication = new MashapeClient(Settings.ClientId, Settings.ClientSecret, Settings.MashapeKey);
            var endpoint = new OAuth2Endpoint(authentication);

            var exception =
                await Record.ExceptionAsync(async () => await endpoint.GetTokenByCodeAsync("abc").ConfigureAwait(false))
                    .ConfigureAwait(false);
            Assert.NotNull(exception);
            Assert.IsType<ImgurException>(exception);
        }

        [Fact]
        [Trait("Category", "OAuth2Endpoint")]
        public async Task GetTokenByRefreshTokenAsync_SetToken_NotNull()
        {
            var authentication = new MashapeClient(Settings.ClientId, Settings.ClientSecret, Settings.MashapeKey);
            var endpoint = new OAuth2Endpoint(authentication);
            var token = await endpoint.GetTokenByRefreshTokenAsync(Settings.RefreshToken).ConfigureAwait(false);

            Assert.NotNull(token);
            Assert.False(string.IsNullOrWhiteSpace(token.AccessToken));
            Assert.False(string.IsNullOrWhiteSpace(token.RefreshToken));
            Assert.False(string.IsNullOrWhiteSpace(token.AccountId));
            Assert.False(string.IsNullOrWhiteSpace(token.TokenType));
        }
    }
}