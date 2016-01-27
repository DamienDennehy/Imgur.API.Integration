using System.Linq;
using System.Threading.Tasks;
using Imgur.API.Authentication.Impl;
using Imgur.API.Endpoints.Impl;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// ReSharper disable ExceptionNotDocumented

namespace Imgur.API.Tests.Integration.Endpoints.AccountEndpointImageTests
{
    [TestClass]
    public class MashapeClientWithOAuth2Tests : TestBase
    {
        [TestMethod]
        [TestCategory("AccountEndpointImage")]
        [ExpectedException(typeof (ImgurException))]
        public async Task DeleteImageAsync_ThrowsImgurException()
        {
            var client = new MashapeClient(ClientId, ClientSecret, MashapeKey, OAuth2Token);
            var endpoint = new AccountEndpoint(client);

            var deleted = await endpoint.DeleteImageAsync("ra06GZN", "sarah").ConfigureAwait(false);

            Assert.IsTrue(deleted);
        }

        [TestMethod]
        [TestCategory("AccountEndpointImage")]
        public async Task GetImageAsync_IsNotNull()
        {
            var client = new MashapeClient(ClientId, ClientSecret, MashapeKey, OAuth2Token);
            var endpoint = new AccountEndpoint(client);

            var image = await endpoint.GetImageAsync("BJRWQw5").ConfigureAwait(false);

            Assert.IsNotNull(image);
        }

        [TestMethod]
        [TestCategory("AccountEndpointImage")]
        public async Task GetImageCountAsync_Any()
        {
            var client = new MashapeClient(ClientId, ClientSecret, MashapeKey, OAuth2Token);
            var endpoint = new AccountEndpoint(client);

            var imageCount = await endpoint.GetImageCountAsync().ConfigureAwait(false);

            Assert.IsTrue(imageCount > 1);
        }

        [TestMethod]
        [TestCategory("AccountEndpointImage")]
        public async Task GetImageIdsAsync_Any()
        {
            var client = new MashapeClient(ClientId, ClientSecret, MashapeKey, OAuth2Token);
            var endpoint = new AccountEndpoint(client);

            var images = await endpoint.GetImageIdsAsync().ConfigureAwait(false);

            Assert.IsTrue(images.Count() > 1);
        }

        [TestMethod]
        [TestCategory("AccountEndpointImage")]
        public async Task GetImagesAsync_Any()
        {
            var client = new MashapeClient(ClientId, ClientSecret, MashapeKey, OAuth2Token);
            var endpoint = new AccountEndpoint(client);

            var images = await endpoint.GetImagesAsync().ConfigureAwait(false);

            Assert.IsTrue(images.Any());
        }
    }
}