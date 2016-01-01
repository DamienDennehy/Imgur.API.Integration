using System;
using System.Threading.Tasks;
using Imgur.API.Authentication.Impl;
using Imgur.API.Endpoints.Impl;
using Imgur.API.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// ReSharper disable ExceptionNotDocumented

namespace Imgur.API.Tests.Integration.Endpoints.AccountEndpointTests
{
    [TestClass]
    public class ImgurClientWithOAuth2Tests : TestBase
    {
        [TestMethod]
        [TestCategory("AccountEndpoint")]
        public async Task GetAccountAsync_WithDefaultUsername_AreEqual()
        {
            var client = new ImgurClient(ClientId, ClientSecret, OAuth2Token);
            var endpoint = new AccountEndpoint(client);

            var account = await endpoint.GetAccountAsync().ConfigureAwait(false);

            Assert.IsTrue(account.Url.Equals("ImgurAPIDotNet", StringComparison.OrdinalIgnoreCase));
        }

        [TestMethod]
        [TestCategory("AccountEndpoint")]
        public async Task GetAccountAsync_WithUsername_AreEqual()
        {
            var client = new ImgurClient(ClientId, ClientSecret, OAuth2Token);
            var endpoint = new AccountEndpoint(client);

            var account = await endpoint.GetAccountAsync("sarah").ConfigureAwait(false);

            Assert.IsTrue("sarah".Equals(account.Url, StringComparison.OrdinalIgnoreCase));
        }

        [TestMethod]
        [TestCategory("AccountEndpoint")]
        public async Task GetAccountSettingsAsync_IsTrue()
        {
            var client = new ImgurClient(ClientId, ClientSecret, OAuth2Token);
            var endpoint = new AccountEndpoint(client);

            var settings = await endpoint.GetAccountSettingsAsync().ConfigureAwait(false);

            Assert.IsFalse(settings.PublicImages);
        }

        [TestMethod]
        [TestCategory("AccountEndpoint")]
        [ExpectedException(typeof (ImgurException))]
        public async Task SendVerificationEmailAsync_IsTrue()
        {
            var client = new ImgurClient(ClientId, ClientSecret, OAuth2Token);
            var endpoint = new AccountEndpoint(client);

            await endpoint.SendVerificationEmailAsync().ConfigureAwait(false);
        }

        [TestMethod]
        [TestCategory("AccountEndpoint")]
        public async Task UpdateAccountSettingsAsync_IsTrue()
        {
            var client = new ImgurClient(ClientId, ClientSecret, OAuth2Token);
            var endpoint = new AccountEndpoint(client);

            var updated =
                await
                    endpoint.UpdateAccountSettingsAsync("ImgurClient_" + DateTimeOffset.UtcNow, false,
                        albumPrivacy: AlbumPrivacy.Hidden).ConfigureAwait(false);

            Assert.IsTrue(updated);
        }

        [TestMethod]
        [TestCategory("AccountEndpoint")]
        public async Task VerifyEmailAsync_IsTrue()
        {
            var client = new ImgurClient(ClientId, ClientSecret, OAuth2Token);
            var endpoint = new AccountEndpoint(client);

            var verified = await endpoint.VerifyEmailAsync().ConfigureAwait(false);

            Assert.IsTrue(verified);
        }
    }
}