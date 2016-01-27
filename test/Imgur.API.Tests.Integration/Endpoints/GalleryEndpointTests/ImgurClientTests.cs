using System.Linq;
using System.Threading.Tasks;
using Imgur.API.Authentication.Impl;
using Imgur.API.Endpoints.Impl;
using Xunit;

// ReSharper disable ExceptionNotDocumented

namespace Imgur.API.Tests.Integration.Endpoints.GalleryEndpointTests
{
    public class ImgurClientTests : TestBase
    {
        [Fact]
        [Trait("Category", "GalleryEndpoint")]
        public async Task GetGalleryAsync_True()
        {
            var client = new ImgurClient(Settings.ClientId, Settings.ClientSecret);
            var endpoint = new GalleryEndpoint(client);

            var gallery = await endpoint.GetGalleryAsync().ConfigureAwait(false);

            Assert.True(gallery.Any());
        }

        [Fact]
        [Trait("Category", "GalleryEndpoint")]
        public async Task GetRandomGalleryAsync_True()
        {
            var client = new ImgurClient(Settings.ClientId, Settings.ClientSecret);
            var endpoint = new GalleryEndpoint(client);

            var gallery = await endpoint.GetRandomGalleryAsync().ConfigureAwait(false);

            Assert.True(gallery.Any());
        }

        [Fact]
        [Trait("Category", "GalleryEndpoint")]
        public async Task SearchGalleryAsync_True()
        {
            var client = new ImgurClient(Settings.ClientId, Settings.ClientSecret);
            var endpoint = new GalleryEndpoint(client);

            var gallery = await endpoint.SearchGalleryAsync("star wars").ConfigureAwait(false);

            Assert.True(gallery.Any());
        }

        [Fact]
        [Trait("Category", "GalleryEndpoint")]
        public async Task SearchGalleryAdvancedAsync_True()
        {
            var client = new ImgurClient(Settings.ClientId, Settings.ClientSecret);
            var endpoint = new GalleryEndpoint(client);

            var gallery = await endpoint.SearchGalleryAdvancedAsync("cats", qNot: "dogs").ConfigureAwait(false);

            Assert.True(gallery.Any());
        }
    }
}