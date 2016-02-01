using System.Threading.Tasks;
using Imgur.API.Authentication.Impl;
using Imgur.API.Endpoints.Impl;
using Imgur.API.Enums;
using Xunit;

// ReSharper disable ExceptionNotDocumented

namespace Imgur.API.Tests.Integration.Endpoints.GalleryEndpointTagTests
{
    public class MashapeClientWithOAuth2Tests : TestBase
    {
        [Fact]
        [Trait("Category", "GalleryEndpoint")]
        public async Task VoteGalleryTagAsync_NotNull()
        {
            var client = new MashapeClient(Settings.ClientId, Settings.MashapeKey, OAuth2Token);
            var endpoint = new GalleryEndpoint(client);

            var voted = await endpoint.VoteGalleryTagAsync("LTUEhhD", "gaming", VoteOption.Up).ConfigureAwait(false);

            Assert.NotNull(voted);
        }
    }
}