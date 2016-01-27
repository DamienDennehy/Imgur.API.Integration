using System.Linq;
using System.Threading.Tasks;
using Imgur.API.Authentication.Impl;
using Imgur.API.Endpoints.Impl;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// ReSharper disable ExceptionNotDocumented

namespace Imgur.API.Tests.Integration.Endpoints.GalleryEndpointImageTests
{
    [TestClass]
    public class ImgurClientTests : TestBase
    {
        [TestMethod]
        [TestCategory("GalleryEndpoint")]
        public async Task GetGalleryImageAsync_AreEqual()
        {
            var client = new ImgurClient(ClientId, ClientSecret);
            var endpoint = new GalleryEndpoint(client);

            var image = await endpoint.GetGalleryImageAsync("BJRWQw5").ConfigureAwait(false);

            Assert.IsNotNull(image);
        }
    }
}