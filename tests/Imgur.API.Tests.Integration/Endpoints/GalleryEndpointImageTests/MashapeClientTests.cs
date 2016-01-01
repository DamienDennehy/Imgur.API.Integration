using System.Linq;
using System.Threading.Tasks;
using Imgur.API.Authentication.Impl;
using Imgur.API.Endpoints.Impl;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// ReSharper disable ExceptionNotDocumented

namespace Imgur.API.Tests.Integration.Endpoints.GalleryEndpointImageTests
{
    [TestClass]
    public class MashapeClientTests : TestBase
    {
        [TestMethod]
        [TestCategory("GalleryEndpoint")]
        public async Task GetGalleryImageAsync_AreEqual()
        {
            var client = new MashapeClient(ClientId, ClientSecret, MashapeKey);
            var endpoint = new GalleryEndpoint(client);

            var image = await endpoint.GetGalleryImageAsync("BJRWQw5").ConfigureAwait(false);

            Assert.IsNotNull(image);
        }
    }
}