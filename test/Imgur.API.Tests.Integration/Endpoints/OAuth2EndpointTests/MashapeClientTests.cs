using System.Threading.Tasks;
using Imgur.API.Authentication.Impl;
using Imgur.API.Endpoints.Impl;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// ReSharper disable ExceptionNotDocumented

namespace Imgur.API.Tests.Integration.Endpoints.OAuth2EndpointTests
{
    [TestClass]
    public class MashapeClientTests : TestBase
    {
        [TestMethod]
        [TestCategory("OAuth2Endpoint")]
        [ExpectedException(typeof (ImgurException))]
        public async Task GetTokenByCodeAsync_SetCodeInvalid_ThrowsImgurException()
        {
            var authentication = new MashapeClient(ClientId, ClientSecret, MashapeKey);
            var endpoint = new OAuth2Endpoint(authentication);
            await endpoint.GetTokenByCodeAsync("abc").ConfigureAwait(false);
        }

        [TestMethod]
        [TestCategory("OAuth2Endpoint")]
        public async Task GetTokenByRefreshTokenAsync_SetToken_IsNotNull()
        {
            var authentication = new MashapeClient(ClientId, ClientSecret, MashapeKey);
            var endpoint = new OAuth2Endpoint(authentication);
            var token = await endpoint.GetTokenByRefreshTokenAsync(RefreshToken).ConfigureAwait(false);

            Assert.IsNotNull(token);
            Assert.IsFalse(string.IsNullOrWhiteSpace(token.AccessToken));
            Assert.IsFalse(string.IsNullOrWhiteSpace(token.RefreshToken));
            Assert.IsFalse(string.IsNullOrWhiteSpace(token.AccountId));
            Assert.IsFalse(string.IsNullOrWhiteSpace(token.TokenType));
        }
    }
}