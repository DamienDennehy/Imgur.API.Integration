using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Imgur.API.Authentication.Impl;
using Imgur.API.Endpoints.Impl;
using Imgur.API.Enums;
using Imgur.API.Models;
using Xunit;

// ReSharper disable ExceptionNotDocumented

namespace Imgur.API.Tests.Integration.Endpoints.CustomGalleryEndpointTests
{
    public class MashapeClientWithOAuth2Tests : TestBase
    {
        [Fact]
        [Trait("Category", "CustomGalleryEndpoint")]
        public async Task AddCustomGalleryTagsAsyncAndRemoveCustomGalleryTagsAsync_True()
        {
            var client = new MashapeClient(Settings.ClientId, Settings.MashapeKey, OAuth2Token);
            var endpoint = new CustomGalleryEndpoint(client);
            var added =
                await endpoint.AddCustomGalleryTagsAsync(new List<string> {"Cats", "Dogs"}).ConfigureAwait(false);

            Assert.True(added);

            var gallery = await endpoint.GetCustomGalleryAsync().ConfigureAwait(false);

            Assert.True(gallery.Tags.Contains("cats"));
            Assert.True(gallery.Tags.Contains("dogs"));

            var removed =
                await endpoint.RemoveCustomGalleryTagsAsync(new List<string> {"cats", "dogs"}).ConfigureAwait(false);

            Assert.True(removed);

            Thread.Sleep(2000);

            gallery = await endpoint.GetCustomGalleryAsync().ConfigureAwait(false);

            Assert.False(gallery.Tags.Contains("cats"));
            Assert.False(gallery.Tags.Contains("dogs"));
        }

        [Fact]
        [Trait("Category", "CustomGalleryEndpoint")]
        public async Task AddFilteredOutGalleryTagAsyncAndRemoveCustomGalleryTagsAsync_True()
        {
            var client = new MashapeClient(Settings.ClientId, Settings.MashapeKey, OAuth2Token);
            var endpoint = new CustomGalleryEndpoint(client);
            var added = await endpoint.AddFilteredOutGalleryTagAsync("movies").ConfigureAwait(false);

            Assert.True(added);

            Thread.Sleep(500);

            var gallery = await endpoint.GetFilteredOutGalleryAsync().ConfigureAwait(false);

            Assert.True(gallery.Tags.Contains("movies"));

            Thread.Sleep(500);

            var removed = await endpoint.RemoveFilteredOutGalleryTagAsync("movies").ConfigureAwait(false);

            Assert.True(removed);

            Thread.Sleep(500);

            gallery = await endpoint.GetFilteredOutGalleryAsync().ConfigureAwait(false);

            Assert.False(gallery.Tags.Contains("movies"));
        }

        [Fact]
        [Trait("Category", "CustomGalleryEndpoint")]
        public async Task GetCustomGalleryAsync_NotNull()
        {
            var client = new MashapeClient(Settings.ClientId, Settings.MashapeKey, OAuth2Token);
            var endpoint = new CustomGalleryEndpoint(client);
            var gallery = await endpoint.GetCustomGalleryAsync().ConfigureAwait(false);
            Assert.NotNull(gallery);
        }

        [Fact]
        [Trait("Category", "CustomGalleryEndpoint")]
        public async Task GetFilteredOutGalleryAsync_NotNull()
        {
            var client = new MashapeClient(Settings.ClientId, Settings.MashapeKey, OAuth2Token);
            var endpoint = new CustomGalleryEndpoint(client);
            var gallery =
                await
                    endpoint.GetFilteredOutGalleryAsync(CustomGallerySortOrder.Top, TimeWindow.All)
                        .ConfigureAwait(false);
            Assert.NotNull(gallery);
        }

        [Fact]
        [Trait("Category", "CustomGalleryEndpoint")]
        public async Task GetCustomGalleryItemAsync_WithImage_NotNull()
        {
            var client = new MashapeClient(Settings.ClientId, Settings.MashapeKey, OAuth2Token);
            var endpoint = new CustomGalleryEndpoint(client);
            var item = await endpoint.GetCustomGalleryItemAsync("02SW9og").ConfigureAwait(false);
            Assert.NotNull(item);
            Assert.True(item is IGalleryImage);
        }

        [Fact]
        [Trait("Category", "CustomGalleryEndpoint")]
        public async Task GetCustomGalleryItemAsync_WithAlbum_NotNull()
        {
            var client = new MashapeClient(Settings.ClientId, Settings.MashapeKey, OAuth2Token);
            var endpoint = new CustomGalleryEndpoint(client);
            var item = await endpoint.GetCustomGalleryItemAsync("jzzwJ").ConfigureAwait(false);
            Assert.NotNull(item);
            Assert.True(item is IGalleryAlbum);
        }
    }
}