using System.Threading.Tasks;
using Imgur.API.Authentication.Impl;
using Imgur.API.Endpoints.Impl;
using Imgur.API.Enums;
using Xunit;

// ReSharper disable ExceptionNotDocumented

namespace Imgur.API.Tests.Integration.Endpoints.GalleryEndpointVoteTests
{
    public class ImgurClientWithOAuth2Tests : TestBase
    {
        [Fact]
        [Trait("Category", "GalleryEndpoint")]
        public async Task VoteGalleryItemAsync_True()
        {
            var client = new ImgurClient(Settings.ClientId, OAuth2Token);
            var endpoint = new GalleryEndpoint(client);

            var voted = await endpoint.VoteGalleryItemAsync("7EhqwbF", VoteOption.Down).ConfigureAwait(false);

            Assert.True(voted);
        }
    }
}