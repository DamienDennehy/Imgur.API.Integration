using System.Threading.Tasks;
using Imgur.API.Authentication.Impl;
using Imgur.API.Endpoints.Impl;
using Imgur.API.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// ReSharper disable ExceptionNotDocumented

namespace Imgur.API.Tests.Integration.Endpoints.GalleryEndpointTagTests
{
    [TestClass]
    public class MashapeClientWithOAuth2Tests : TestBase
    {
        [TestMethod]
        [TestCategory("GalleryEndpoint")]
        public async Task VoteGalleryTagAsync_IsNotNull()
        {
            var client = new MashapeClient(Settings.ClientId, Settings.ClientSecret, Settings.MashapeKey, OAuth2Token);
            var endpoint = new GalleryEndpoint(client);

            var voted = await endpoint.VoteGalleryTagAsync("LTUEhhD", "gaming", VoteOption.Up).ConfigureAwait(false);

            Assert.IsNotNull(voted);
        }
    }
}