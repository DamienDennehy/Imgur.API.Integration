using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Imgur.API.Authentication.Impl;
using Imgur.API.Endpoints.Impl;
using Imgur.API.Enums;
using Imgur.API.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// ReSharper disable ExceptionNotDocumented

namespace Imgur.API.Tests.Integration.Endpoints.CustomGalleryEndpointTests
{
    [TestClass]
    public class ImgurClientWithOAuth2Tests : TestBase
    {
        [TestMethod]
        [TestCategory("CustomGalleryEndpoint")]
        public async Task AddCustomGalleryTagsAsyncAndRemoveCustomGalleryTagsAsync_IsTrue()
        {
            var client = new ImgurClient(Settings.ClientId, Settings.ClientSecret, OAuth2Token);
            var endpoint = new CustomGalleryEndpoint(client);

            await endpoint.RemoveCustomGalleryTagsAsync(new List<string> {"cats", "dogs"}).ConfigureAwait(false);

            var added =
                await endpoint.AddCustomGalleryTagsAsync(new List<string> {"Cats", "Dogs"}).ConfigureAwait(false);

            Assert.IsTrue(added);

            var gallery = await endpoint.GetCustomGalleryAsync().ConfigureAwait(false);

            Assert.IsTrue(gallery.Tags.Contains("cats"));
            Assert.IsTrue(gallery.Tags.Contains("dogs"));

            var removed =
                await endpoint.RemoveCustomGalleryTagsAsync(new List<string> {"cats", "dogs"}).ConfigureAwait(false);

            Assert.IsTrue(removed);

            gallery = await endpoint.GetCustomGalleryAsync().ConfigureAwait(false);

            Assert.IsFalse(gallery.Tags.Contains("cats"));
            Assert.IsFalse(gallery.Tags.Contains("dogs"));
        }

        [TestMethod]
        [TestCategory("CustomGalleryEndpoint")]
        public async Task AddFilteredOutGalleryTagAsyncAndRemoveCustomGalleryTagsAsync_IsTrue()
        {
            var client = new ImgurClient(Settings.ClientId, Settings.ClientSecret, OAuth2Token);
            var endpoint = new CustomGalleryEndpoint(client);

            await endpoint.RemoveFilteredOutGalleryTagAsync("movies").ConfigureAwait(false);
            var added = await endpoint.AddFilteredOutGalleryTagAsync("movies").ConfigureAwait(false);

            Assert.IsTrue(added);

            Thread.Sleep(500);

            var gallery = await endpoint.GetFilteredOutGalleryAsync().ConfigureAwait(false);

            Assert.IsTrue(gallery.Tags.Contains("movies"));

            Thread.Sleep(500);

            var removed = await endpoint.RemoveFilteredOutGalleryTagAsync("movies").ConfigureAwait(false);

            Assert.IsTrue(removed);

            Thread.Sleep(500);

            gallery = await endpoint.GetFilteredOutGalleryAsync().ConfigureAwait(false);

            Assert.IsFalse(gallery.Tags.Contains("movies"));
        }

        [TestMethod]
        [TestCategory("CustomGalleryEndpoint")]
        public async Task GetCustomGalleryAsync_IsNotNull()
        {
            var client = new ImgurClient(Settings.ClientId, Settings.ClientSecret, OAuth2Token);
            var endpoint = new CustomGalleryEndpoint(client);
            var gallery = await endpoint.GetCustomGalleryAsync().ConfigureAwait(false);
            Assert.IsNotNull(gallery);
        }

        [TestMethod]
        [TestCategory("CustomGalleryEndpoint")]
        public async Task GetFilteredOutGalleryAsync_IsNotNull()
        {
            var client = new ImgurClient(Settings.ClientId, Settings.ClientSecret, OAuth2Token);
            var endpoint = new CustomGalleryEndpoint(client);
            var gallery =
                await
                    endpoint.GetFilteredOutGalleryAsync(CustomGallerySortOrder.Top, TimeWindow.All)
                        .ConfigureAwait(false);
            Assert.IsNotNull(gallery);
        }

        [TestMethod]
        [TestCategory("CustomGalleryEndpoint")]
        public async Task GetCustomGalleryItemAsync_WithImage_IsNotNull()
        {
            var client = new ImgurClient(Settings.ClientId, Settings.ClientSecret, OAuth2Token);
            var endpoint = new CustomGalleryEndpoint(client);
            var item = await endpoint.GetCustomGalleryItemAsync("02SW9og").ConfigureAwait(false);
            Assert.IsNotNull(item);
            Assert.IsTrue(item is IGalleryImage);
        }

        [TestMethod]
        [TestCategory("CustomGalleryEndpoint")]
        public async Task GetCustomGalleryItemAsync_WithAlbum_IsNotNull()
        {
            var client = new ImgurClient(Settings.ClientId, Settings.ClientSecret, OAuth2Token);
            var endpoint = new CustomGalleryEndpoint(client);
            var item = await endpoint.GetCustomGalleryItemAsync("jzzwJ").ConfigureAwait(false);
            Assert.IsNotNull(item);
            Assert.IsTrue(item is IGalleryAlbum);
        }
    }
}