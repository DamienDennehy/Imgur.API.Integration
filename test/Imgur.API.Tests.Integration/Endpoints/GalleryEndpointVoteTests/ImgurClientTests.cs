using System.Threading.Tasks;
using Imgur.API.Authentication.Impl;
using Imgur.API.Endpoints.Impl;
using Xunit;

// ReSharper disable ExceptionNotDocumented

namespace Imgur.API.Tests.Integration.Endpoints.GalleryEndpointVoteTests
{
    public class ImgurClientTests : TestBase
    {
        [Fact]
        [Trait("Category", "GalleryEndpoint")]
        public async Task GetGalleryItemVotesAsync_Any()
        {
            var client = new ImgurClient(Settings.ClientId, Settings.ClientSecret);
            var endpoint = new GalleryEndpoint(client);

            var votes = await endpoint.GetGalleryItemVotesAsync("7EhqwbF").ConfigureAwait(false);

            Assert.NotNull(votes);
        }
    }
}