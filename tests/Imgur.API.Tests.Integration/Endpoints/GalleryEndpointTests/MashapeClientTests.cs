using System.Linq;
using System.Threading.Tasks;
using Imgur.API.Authentication.Impl;
using Imgur.API.Endpoints.Impl;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// ReSharper disable ExceptionNotDocumented

namespace Imgur.API.Tests.Integration.Endpoints.GalleryEndpointTests
{
    [TestClass]
    public class MashapeClientTests : TestBase
    {
        [TestMethod]
        [TestCategory("GalleryEndpoint")]
        public async Task GetGalleryAsync_IsTrue()
        {
            var client = new MashapeClient(ClientId, ClientSecret, MashapeKey);
            var endpoint = new GalleryEndpoint(client);

            var gallery = await endpoint.GetGalleryAsync().ConfigureAwait(false);

            Assert.IsTrue(gallery.Any());
        }

        [TestMethod]
        [TestCategory("GalleryEndpoint")]
        public async Task GetRandomGalleryAsync_IsTrue()
        {
            var client = new MashapeClient(ClientId, ClientSecret, MashapeKey);
            var endpoint = new GalleryEndpoint(client);

            var gallery = await endpoint.GetRandomGalleryAsync().ConfigureAwait(false);

            Assert.IsTrue(gallery.Any());
        }

        [TestMethod]
        [TestCategory("GalleryEndpoint")]
        public async Task SearchGalleryAsync_IsTrue()
        {
            var client = new MashapeClient(ClientId, ClientSecret, MashapeKey);
            var endpoint = new GalleryEndpoint(client);

            var gallery = await endpoint.SearchGalleryAsync("star wars").ConfigureAwait(false);

            Assert.IsTrue(gallery.Any());
        }

        [TestMethod]
        [TestCategory("GalleryEndpoint")]
        public async Task SearchGalleryAdvancedAsync_IsTrue()
        {
            var client = new MashapeClient(ClientId, ClientSecret, MashapeKey);
            var endpoint = new GalleryEndpoint(client);

            var gallery = await endpoint.SearchGalleryAdvancedAsync("cats", qNot: "dogs").ConfigureAwait(false);

            Assert.IsTrue(gallery.Any());
        }
    }
}