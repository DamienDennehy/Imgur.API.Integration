using System.Linq;
using System.Threading.Tasks;
using Imgur.API.Authentication.Impl;
using Imgur.API.Endpoints.Impl;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// ReSharper disable ExceptionNotDocumented

namespace Imgur.API.Tests.Integration.Endpoints.AccountEndpointGalleryTests
{
    [TestClass]
    public class MashapeClientWithOAuth2Tests : TestBase
    {
        [TestMethod]
        [TestCategory("AccountEndpointGallery")]
        public async Task GetAccountFavoritesAsync_Any()
        {
            var client = new MashapeClient(Settings.ClientId, Settings.ClientSecret, Settings.MashapeKey, OAuth2Token);
            var endpoint = new AccountEndpoint(client);

            var submissions = await endpoint.GetAccountFavoritesAsync().ConfigureAwait(false);

            Assert.IsTrue(submissions.Any());
        }

        [TestMethod]
        [TestCategory("AccountEndpointGallery")]
        public async Task GetAccountGalleryFavoritesAsync_Any()
        {
            var client = new MashapeClient(Settings.ClientId, Settings.ClientSecret, Settings.MashapeKey, OAuth2Token);
            var endpoint = new AccountEndpoint(client);

            var favourites = await endpoint.GetAccountGalleryFavoritesAsync().ConfigureAwait(false);

            Assert.IsTrue(favourites.Any());
        }

        [TestMethod]
        [TestCategory("AccountEndpointGallery")]
        public async Task GetAccountSubmissionsAsync_Any()
        {
            var client = new MashapeClient(Settings.ClientId, Settings.ClientSecret, Settings.MashapeKey, OAuth2Token);
            var endpoint = new AccountEndpoint(client);

            var submissions = await endpoint.GetAccountSubmissionsAsync().ConfigureAwait(false);

            Assert.IsTrue(submissions.Any());
        }

        [TestMethod]
        [TestCategory("AccountEndpointGallery")]
        public async Task GetGalleryProfileAsync_IsNotNull()
        {
            var client = new MashapeClient(Settings.ClientId, Settings.ClientSecret, Settings.MashapeKey, OAuth2Token);
            var endpoint = new AccountEndpoint(client);

            var profile = await endpoint.GetGalleryProfileAsync().ConfigureAwait(false);

            Assert.IsNotNull(profile);
        }
    }
}