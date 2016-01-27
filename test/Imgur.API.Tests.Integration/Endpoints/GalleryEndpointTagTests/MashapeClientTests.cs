using System.Linq;
using System.Threading.Tasks;
using Imgur.API.Authentication.Impl;
using Imgur.API.Endpoints.Impl;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// ReSharper disable ExceptionNotDocumented

namespace Imgur.API.Tests.Integration.Endpoints.GalleryEndpointTagTests
{
    [TestClass]
    public class MashapeClientTests : TestBase
    {
        [TestMethod]
        [TestCategory("GalleryEndpoint")]
        public async Task GetGalleryItemTagsAsync_Any()
        {
            var client = new MashapeClient(Settings.ClientId, Settings.ClientSecret, Settings.MashapeKey);
            var endpoint = new GalleryEndpoint(client);

            var tags = await endpoint.GetGalleryItemTagsAsync("7EhqwbF").ConfigureAwait(false);

            Assert.IsNotNull(tags);
            Assert.IsTrue(tags.Tags.Any());
        }

        [TestMethod]
        [TestCategory("GalleryEndpoint")]
        public async Task GetGalleryTagAsync_IsNotNull()
        {
            var client = new MashapeClient(Settings.ClientId, Settings.ClientSecret, Settings.MashapeKey);
            var endpoint = new GalleryEndpoint(client);

            var tag = await endpoint.GetGalleryTagAsync("gaming").ConfigureAwait(false);

            Assert.IsNotNull(tag);
            Assert.IsTrue(tag.Items.Any());
        }

        [TestMethod]
        [TestCategory("GalleryEndpoint")]
        public async Task GetGalleryTagImageAsync_IsNotNull()
        {
            var client = new MashapeClient(Settings.ClientId, Settings.ClientSecret, Settings.MashapeKey);
            var endpoint = new GalleryEndpoint(client);

            var image = await endpoint.GetGalleryTagImageAsync("LTUEhhD", "gaming").ConfigureAwait(false);

            Assert.IsNotNull(image);
        }
    }
}