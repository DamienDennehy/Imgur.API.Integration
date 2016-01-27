using System.Threading.Tasks;
using Imgur.API.Authentication.Impl;
using Imgur.API.Endpoints.Impl;
using Imgur.API.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// ReSharper disable ExceptionNotDocumented

namespace Imgur.API.Tests.Integration.Endpoints.GalleryEndpointVoteTests
{
    [TestClass]
    public class ImgurClientWithOAuth2Tests : TestBase
    {
        [TestMethod]
        [TestCategory("GalleryEndpoint")]
        public async Task VoteGalleryItemAsync_IsTrue()
        {
            var client = new ImgurClient(Settings.ClientId, Settings.ClientSecret, OAuth2Token);
            var endpoint = new GalleryEndpoint(client);

            var voted = await endpoint.VoteGalleryItemAsync("7EhqwbF", VoteOption.Down).ConfigureAwait(false);

            Assert.IsTrue(voted);
        }
    }
}