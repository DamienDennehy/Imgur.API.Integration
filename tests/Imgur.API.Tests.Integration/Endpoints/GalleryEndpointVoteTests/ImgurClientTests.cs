using System.Linq;
using System.Threading.Tasks;
using Imgur.API.Authentication.Impl;
using Imgur.API.Endpoints.Impl;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// ReSharper disable ExceptionNotDocumented

namespace Imgur.API.Tests.Integration.Endpoints.GalleryEndpointVoteTests
{
    [TestClass]
    public class ImgurClientTests : TestBase
    {
        [TestMethod]
        [TestCategory("GalleryEndpoint")]
        public async Task GetGalleryItemVotesAsync_Any()
        {
            var client = new ImgurClient(ClientId, ClientSecret);
            var endpoint = new GalleryEndpoint(client);

            var votes = await endpoint.GetGalleryItemVotesAsync("7EhqwbF").ConfigureAwait(false);

            Assert.IsNotNull(votes);
        }
    }
}