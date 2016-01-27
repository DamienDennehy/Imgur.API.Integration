﻿using System.Linq;
using System.Threading.Tasks;
using Imgur.API.Authentication.Impl;
using Imgur.API.Endpoints.Impl;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// ReSharper disable ExceptionNotDocumented

namespace Imgur.API.Tests.Integration.Endpoints.GalleryEndpointSubredditTests
{
    [TestClass]
    public class ImgurClientTests : TestBase
    {
        [TestMethod]
        [TestCategory("GalleryEndpoint")]
        public async Task GetSubredditGalleryAsync_Any()
        {
            var client = new ImgurClient(ClientId, ClientSecret);
            var endpoint = new GalleryEndpoint(client);

            var subreddit = await endpoint.GetSubredditGalleryAsync("gaming").ConfigureAwait(false);

            Assert.IsTrue(subreddit.Any());
        }

        [TestMethod]
        [TestCategory("GalleryEndpoint")]
        public async Task GetSubredditImageAsync_IsNotNull()
        {
            var client = new ImgurClient(ClientId, ClientSecret);
            var endpoint = new GalleryEndpoint(client);

            var image = await endpoint.GetSubredditImageAsync("wPWniy2", "gaming").ConfigureAwait(false);

            Assert.IsNotNull(image);
        }
    }
}