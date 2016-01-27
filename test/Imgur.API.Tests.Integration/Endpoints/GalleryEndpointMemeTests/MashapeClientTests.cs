using System.Linq;
using System.Threading.Tasks;
using Imgur.API.Authentication.Impl;
using Imgur.API.Endpoints.Impl;
using Xunit;

// ReSharper disable ExceptionNotDocumented

namespace Imgur.API.Tests.Integration.Endpoints.GalleryEndpointMemeTests
{
    public class MashapeClientTests : TestBase
    {
        [Fact]
        [Trait("Category", "GalleryEndpoint")]
        public async Task GetMemesSubGalleryAsync_Any()
        {
            var client = new MashapeClient(Settings.ClientId, Settings.ClientSecret, Settings.MashapeKey);
            var endpoint = new GalleryEndpoint(client);

            var memes = await endpoint.GetMemesSubGalleryAsync().ConfigureAwait(false);

            Assert.True(memes.Any());
        }

        [Fact]
        [Trait("Category", "GalleryEndpoint")]
        public async Task GetMemesSubGalleryImageAsync_NotNull()
        {
            var client = new MashapeClient(Settings.ClientId, Settings.ClientSecret, Settings.MashapeKey);
            var endpoint = new GalleryEndpoint(client);

            var meme = await endpoint.GetMemesSubGalleryImageAsync("qjHJPWZ").ConfigureAwait(false);

            Assert.NotNull(meme);
        }
    }
}