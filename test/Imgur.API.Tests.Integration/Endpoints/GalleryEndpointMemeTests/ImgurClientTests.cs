using System.Linq;
using System.Threading.Tasks;
using Imgur.API.Authentication.Impl;
using Imgur.API.Endpoints.Impl;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// ReSharper disable ExceptionNotDocumented

namespace Imgur.API.Tests.Integration.Endpoints.GalleryEndpointMemeTests
{
    [TestClass]
    public class ImgurClientTests : TestBase
    {
        [TestMethod]
        [TestCategory("GalleryEndpoint")]
        public async Task GetMemesSubGalleryAsync_Any()
        {
            var client = new ImgurClient(ClientId, ClientSecret);
            var endpoint = new GalleryEndpoint(client);

            var memes = await endpoint.GetMemesSubGalleryAsync().ConfigureAwait(false);

            Assert.IsTrue(memes.Any());
        }

        [TestMethod]
        [TestCategory("GalleryEndpoint")]
        public async Task GetMemesSubGalleryImageAsync_IsNotNull()
        {
            var client = new ImgurClient(ClientId, ClientSecret);
            var endpoint = new GalleryEndpoint(client);

            var meme = await endpoint.GetMemesSubGalleryImageAsync("qjHJPWZ").ConfigureAwait(false);

            Assert.IsNotNull(meme);
        }
    }
}