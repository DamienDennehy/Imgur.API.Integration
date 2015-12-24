using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Imgur.API.Authentication.Impl;
using Imgur.API.Endpoints.Impl;
using Imgur.API.Enums;
using Imgur.API.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Imgur.API.Tests.Integration.Endpoints.CustomGalleryEndpointTests
{
    [TestClass]
    public class ImgurClientWithOAuth2Tests : TestBase
    {
        [TestMethod]
        [TestCategory("CustomGalleryEndpoint")]
        public async Task AddCustomGalleryTagsAsyncAndRemoveCustomGalleryTagsAsync_IsTrue()
        {
            var client = new ImgurClient(ClientId, ClientSecret, OAuth2Token);
            var endpoint = new CustomGalleryEndpoint(client);

            await endpoint.RemoveCustomGalleryTagsAsync(new List<string> { "cats", "dogs" });

            var added = await endpoint.AddCustomGalleryTagsAsync(new List<string> { "Cats", "Dogs" });

            Assert.IsTrue(added);

            var gallery = await endpoint.GetCustomGalleryAsync();

            Assert.IsTrue(gallery.Tags.Contains("cats"));
            Assert.IsTrue(gallery.Tags.Contains("dogs"));

            var removed = await endpoint.RemoveCustomGalleryTagsAsync(new List<string> { "cats", "dogs" });

            Assert.IsTrue(removed);

            gallery = await endpoint.GetCustomGalleryAsync();

            Assert.IsFalse(gallery.Tags.Contains("cats"));
            Assert.IsFalse(gallery.Tags.Contains("dogs"));
        }

        [TestMethod]
        [TestCategory("CustomGalleryEndpoint")]
        public async Task AddFilteredOutGalleryTagAsyncAndRemoveCustomGalleryTagsAsync_IsTrue()
        {
            var client = new ImgurClient(ClientId, ClientSecret, OAuth2Token);
            var endpoint = new CustomGalleryEndpoint(client);

            await endpoint.RemoveFilteredOutGalleryTagAsync("movies");
            var added = await endpoint.AddFilteredOutGalleryTagAsync("movies");

            Assert.IsTrue(added);
            
            var gallery = await endpoint.GetFilteredOutGalleryAsync();
            
            Assert.IsTrue(gallery.Tags.Contains("movies"));
            
            var removed = await endpoint.RemoveFilteredOutGalleryTagAsync("movies");

            Assert.IsTrue(removed);
            
            gallery = await endpoint.GetFilteredOutGalleryAsync();

            Assert.IsFalse(gallery.Tags.Contains("movies"));
        }

        [TestMethod]
        [TestCategory("CustomGalleryEndpoint")]
        public async Task GetCustomGalleryAsync_IsNotNull()
        {
            var client = new ImgurClient(ClientId, ClientSecret, OAuth2Token);
            var endpoint = new CustomGalleryEndpoint(client);
            var gallery = await endpoint.GetCustomGalleryAsync();
            Assert.IsNotNull(gallery);
        }

        [TestMethod]
        [TestCategory("CustomGalleryEndpoint")]
        public async Task GetFilteredOutGalleryAsync_IsNotNull()
        {
            var client = new ImgurClient(ClientId, ClientSecret, OAuth2Token);
            var endpoint = new CustomGalleryEndpoint(client);
            var gallery = await endpoint.GetFilteredOutGalleryAsync(CustomGallerySortOrder.Top, Window.All);
            Assert.IsNotNull(gallery);
        }

        [TestMethod]
        [TestCategory("CustomGalleryEndpoint")]
        public async Task GetCustomGalleryItemAsync_WithImage_IsNotNull()
        {
            var client = new ImgurClient(ClientId, ClientSecret, OAuth2Token);
            var endpoint = new CustomGalleryEndpoint(client);
            var item = await endpoint.GetCustomGalleryItemAsync("02SW9og");
            Assert.IsNotNull(item);
            Assert.IsTrue(item is IGalleryImage);
        }
        
        [TestMethod]
        [TestCategory("CustomGalleryEndpoint")]
        public async Task GetCustomGalleryItemAsync_WithAlbum_IsNotNull()
        {
            var client = new ImgurClient(ClientId, ClientSecret, OAuth2Token);
            var endpoint = new CustomGalleryEndpoint(client);
            var item = await endpoint.GetCustomGalleryItemAsync("jzzwJ");
            Assert.IsNotNull(item);
            Assert.IsTrue(item is IGalleryAlbum);
        }
    }
}
