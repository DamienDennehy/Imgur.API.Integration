using System.Threading.Tasks;
using Imgur.API.Authentication.Impl;
using Imgur.API.Endpoints.Impl;
using Xunit;

// ReSharper disable ExceptionNotDocumented

namespace Imgur.API.Tests.Integration.Endpoints.GalleryEndpointAlbumTests
{
    public class MashapeClientTests : TestBase
    {
        [Fact]
        [Trait("Category", "GalleryEndpoint")]
        public async Task GetGalleryAlbumAsync_Equal()
        {
            var client = new MashapeClient(Settings.ClientId, Settings.ClientSecret, Settings.MashapeKey);
            var endpoint = new GalleryEndpoint(client);

            var gallery = await endpoint.GetGalleryAlbumAsync("9cYFV").ConfigureAwait(false);

            Assert.NotNull(gallery);
        }
    }
}