﻿using System.Linq;
using System.Threading.Tasks;
using Imgur.API.Authentication.Impl;
using Imgur.API.Endpoints.Impl;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// ReSharper disable ExceptionNotDocumented

namespace Imgur.API.Tests.Integration.Endpoints.AccountEndpointAlbumTests
{
    [TestClass]
    public class ImgurClientTests : TestBase
    {
        [TestMethod]
        [TestCategory("AccountEndpointAlbum")]
        public async Task GetAlbumAsync_IsNotNull()
        {
            var client = new ImgurClient(ClientId, ClientSecret);
            var endpoint = new AccountEndpoint(client);

            var album = await endpoint.GetAlbumAsync("SbU9Y", "sarah").ConfigureAwait(false);

            Assert.IsNotNull(album);
        }

        [TestMethod]
        [TestCategory("AccountEndpointAlbum")]
        public async Task GetAlbumCountAsync_GreaterThan100()
        {
            var client = new ImgurClient(ClientId, ClientSecret);
            var endpoint = new AccountEndpoint(client);

            var albums = await endpoint.GetAlbumCountAsync("sarah").ConfigureAwait(false);

            Assert.IsTrue(albums > 100);
        }

        [TestMethod]
        [TestCategory("AccountEndpointAlbum")]
        public async Task GetAlbumIdsAsync_AreEqual()
        {
            var client = new ImgurClient(ClientId, ClientSecret);
            var endpoint = new AccountEndpoint(client);

            var albums = await endpoint.GetAlbumIdsAsync("sarah").ConfigureAwait(false);

            Assert.AreEqual(50, albums.Count());
        }

        [TestMethod]
        [TestCategory("AccountEndpointAlbum")]
        public async Task GetAlbumsAsync_AreEqual()
        {
            var client = new ImgurClient(ClientId, ClientSecret);
            var endpoint = new AccountEndpoint(client);

            var albums = await endpoint.GetAlbumsAsync("sarah").ConfigureAwait(false);

            Assert.AreEqual(50, albums.Count());
        }
    }
}