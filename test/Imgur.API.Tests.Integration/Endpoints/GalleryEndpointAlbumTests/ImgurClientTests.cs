using System.Threading.Tasks;
using Imgur.API.Authentication.Impl;
using Imgur.API.Endpoints.Impl;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// ReSharper disable ExceptionNotDocumented

namespace Imgur.API.Tests.Integration.Endpoints.GalleryEndpointAlbumTests
{
    [TestClass]
    public class ImgurClientTests : TestBase
    {
        [TestMethod]
        [TestCategory("GalleryEndpoint")]
        public async Task GetGalleryAlbumAsync_AreEqual()
        {
            var client = new ImgurClient(ClientId, ClientSecret);
            var endpoint = new GalleryEndpoint(client);

            var gallery = await endpoint.GetGalleryAlbumAsync("9cYFV").ConfigureAwait(false);

            Assert.IsNotNull(gallery);
        }
    }
}