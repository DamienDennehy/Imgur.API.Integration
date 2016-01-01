using System.Linq;
using System.Threading.Tasks;
using Imgur.API.Authentication.Impl;
using Imgur.API.Endpoints.Impl;
using Imgur.API.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// ReSharper disable ExceptionNotDocumented

namespace Imgur.API.Tests.Integration.Endpoints.GalleryEndpointTagTests
{
    [TestClass]
    public class ImgurClientWithOAuth2Tests : TestBase
    {
        [TestMethod]
        [TestCategory("GalleryEndpoint")]
        public async Task VoteGalleryTagAsync_IsTrue()
        {
            var client = new ImgurClient(ClientId, ClientSecret, OAuth2Token);
            var endpoint = new GalleryEndpoint(client);

            var voted = await endpoint.VoteGalleryTagAsync("LTUEhhD", "gaming", VoteOption.Up).ConfigureAwait(false);
            
            Assert.IsTrue(voted);
        }
    }
}