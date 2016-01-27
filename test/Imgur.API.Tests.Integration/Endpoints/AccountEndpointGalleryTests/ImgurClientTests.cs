using System.Linq;
using System.Threading.Tasks;
using Imgur.API.Authentication.Impl;
using Imgur.API.Endpoints.Impl;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// ReSharper disable ExceptionNotDocumented

namespace Imgur.API.Tests.Integration.Endpoints.AccountEndpointGalleryTests
{
    [TestClass]
    public class ImgurClientTests : TestBase
    {
        [TestMethod]
        [TestCategory("AccountEndpointGallery")]
        public async Task GetAccountGalleryFavoritesAsync_Any()
        {
            var client = new ImgurClient(Settings.ClientId, Settings.ClientSecret);
            var endpoint = new AccountEndpoint(client);

            var favourites = await endpoint.GetAccountGalleryFavoritesAsync("sarah").ConfigureAwait(false);

            Assert.IsTrue(favourites.Any());
        }

        [TestMethod]
        [TestCategory("AccountEndpointGallery")]
        public async Task GetAccountSubmissionsAsync_Any()
        {
            var client = new ImgurClient(Settings.ClientId, Settings.ClientSecret);
            var endpoint = new AccountEndpoint(client);

            var submissions = await endpoint.GetAccountSubmissionsAsync("sarah").ConfigureAwait(false);

            Assert.IsTrue(submissions.Any());
        }

        [TestMethod]
        [TestCategory("AccountEndpointGallery")]
        public async Task GetGalleryProfileAsync_AnyTrophies()
        {
            var client = new ImgurClient(Settings.ClientId, Settings.ClientSecret);
            var endpoint = new AccountEndpoint(client);

            var profile = await endpoint.GetGalleryProfileAsync("sarah").ConfigureAwait(false);

            Assert.IsTrue(profile.Trophies.Any());
        }
    }
}