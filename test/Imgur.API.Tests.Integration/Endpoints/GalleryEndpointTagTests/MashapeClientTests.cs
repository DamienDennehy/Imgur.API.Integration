using System.Linq;
using System.Threading.Tasks;
using Imgur.API.Authentication.Impl;
using Imgur.API.Endpoints.Impl;
using Xunit;

// ReSharper disable ExceptionNotDocumented

namespace Imgur.API.Tests.Integration.Endpoints.GalleryEndpointTagTests
{
    public class MashapeClientTests : TestBase
    {
        [Fact]
        [Trait("Category", "GalleryEndpoint")]
        public async Task GetGalleryItemTagsAsync_Any()
        {
            var client = new MashapeClient(Settings.ClientId, Settings.MashapeKey);
            var endpoint = new GalleryEndpoint(client);

            var tags = await endpoint.GetGalleryItemTagsAsync("7EhqwbF").ConfigureAwait(false);

            Assert.NotNull(tags);
            Assert.True(tags.Tags.Any());
        }

        [Fact]
        [Trait("Category", "GalleryEndpoint")]
        public async Task GetGalleryTagAsync_NotNull()
        {
            var client = new MashapeClient(Settings.ClientId, Settings.MashapeKey);
            var endpoint = new GalleryEndpoint(client);

            var tag = await endpoint.GetGalleryTagAsync("gaming").ConfigureAwait(false);

            Assert.NotNull(tag);
            Assert.True(tag.Items.Any());
        }

        [Fact]
        [Trait("Category", "GalleryEndpoint")]
        public async Task GetGalleryTagImageAsync_NotNull()
        {
            var client = new MashapeClient(Settings.ClientId, Settings.MashapeKey);
            var endpoint = new GalleryEndpoint(client);

            var image = await endpoint.GetGalleryTagImageAsync("LTUEhhD", "gaming").ConfigureAwait(false);

            Assert.NotNull(image);
        }
    }
}