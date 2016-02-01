using System.Threading.Tasks;
using Imgur.API.Authentication.Impl;
using Imgur.API.Endpoints.Impl;
using Xunit;

// ReSharper disable ExceptionNotDocumented

namespace Imgur.API.Tests.Integration.Endpoints.GalleryEndpointImageTests
{
    public class ImgurClientTests : TestBase
    {
        [Fact]
        [Trait("Category", "GalleryEndpoint")]
        public async Task GetGalleryImageAsync_Equal()
        {
            var client = new ImgurClient(Settings.ClientId);
            var endpoint = new GalleryEndpoint(client);

            var image = await endpoint.GetGalleryImageAsync("BJRWQw5").ConfigureAwait(false);

            Assert.NotNull(image);
        }
    }
}