﻿using System.Linq;
using System.Threading.Tasks;
using Imgur.API.Authentication.Impl;
using Imgur.API.Endpoints.Impl;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// ReSharper disable ExceptionNotDocumented

namespace Imgur.API.Tests.Integration.Endpoints.AccountEndpointAlbumTests
{
    [TestClass]
    public class MashapeClientWithOAuth2Tests : TestBase
    {
        [TestMethod]
        [TestCategory("AccountEndpointAlbum")]
        [ExpectedException(typeof (ImgurException))]
        public async Task DeleteAlbumAsync_ThrowsImgurException()
        {
            var client = new MashapeClient(ClientId, ClientSecret, MashapeKey, OAuth2Token);
            var endpoint = new AccountEndpoint(client);

            var deleted = await endpoint.DeleteAlbumAsync("lzpoZ7a5IPrxvVe").ConfigureAwait(false);

            Assert.IsTrue(deleted);
        }

        [TestMethod]
        [TestCategory("AccountEndpointAlbum")]
        public async Task GetAlbumAsync_WithValidReponse_AreEqual()
        {
            var client = new MashapeClient(ClientId, ClientSecret, MashapeKey, OAuth2Token);
            var endpoint = new AccountEndpoint(client);

            var album = await endpoint.GetAlbumAsync("cuta6").ConfigureAwait(false);

            Assert.IsNotNull(album);
        }

        [TestMethod]
        [TestCategory("AccountEndpointAlbum")]
        public async Task GetAlbumCountAsync_WithValidReponse_AreEqual()
        {
            var client = new MashapeClient(ClientId, ClientSecret, MashapeKey, OAuth2Token);
            var endpoint = new AccountEndpoint(client);

            var albums = await endpoint.GetAlbumCountAsync().ConfigureAwait(false);

            Assert.IsTrue(albums >= 1);
        }

        [TestMethod]
        [TestCategory("AccountEndpointAlbum")]
        public async Task GetAlbumIdsAsync_Any()
        {
            var client = new MashapeClient(ClientId, ClientSecret, MashapeKey, OAuth2Token);
            var endpoint = new AccountEndpoint(client);

            var albums = await endpoint.GetAlbumIdsAsync().ConfigureAwait(false);

            Assert.IsTrue(albums.Any());
        }

        [TestMethod]
        [TestCategory("AccountEndpointAlbum")]
        public async Task GetAlbumsAsync_IsTrue()
        {
            var client = new MashapeClient(ClientId, ClientSecret, MashapeKey, OAuth2Token);
            var endpoint = new AccountEndpoint(client);

            var albums = await endpoint.GetAlbumsAsync().ConfigureAwait(false);

            Assert.IsTrue(albums.Any());
        }
    }
}