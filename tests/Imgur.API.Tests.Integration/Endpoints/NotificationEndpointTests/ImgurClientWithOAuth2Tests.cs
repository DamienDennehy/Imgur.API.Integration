using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Imgur.API.Authentication.Impl;
using Imgur.API.Endpoints.Impl;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Imgur.API.Tests.Integration.Endpoints.NotificationEndpointTests
{
    [TestClass]
    public class ImgurClientWithOAuth2Tests : TestBase
    {
        [TestMethod]
        [TestCategory("NotificationEndpoint")]
        public async Task GetNotificationsAsync_AreEqual()
        {
            var client = new ImgurClient(ClientId, ClientSecret, OAuth2Token);
            var endpoint = new NotificationEndpoint(client);

            var notifications = await endpoint.GetNotificationsAsync();

            Assert.IsNotNull(notifications);
        }

        [TestMethod]
        [TestCategory("NotificationEndpoint")]
        public async Task GetNotificationAsync_AreEqual()
        {
            var client = new ImgurClient(ClientId, ClientSecret, OAuth2Token);
            var endpoint = new NotificationEndpoint(client);

            var notification = await endpoint.GetNotificationAsync("322888961");

            Assert.IsNotNull(notification);
        }

        [TestMethod]
        [TestCategory("NotificationEndpoint")]
        public async Task MarkNotificationViewedAsync_IsFalse()
        {
            var client = new ImgurClient(ClientId, ClientSecret, OAuth2Token);
            var endpoint = new NotificationEndpoint(client);

            var marked = await endpoint.MarkNotificationViewedAsync("322888961");

            Assert.IsFalse(marked);
        }

        [TestMethod]
        [TestCategory("NotificationEndpoint")]
        public async Task MarkNotificationsViewedAsync_IsFalse()
        {
            var client = new ImgurClient(ClientId, ClientSecret, OAuth2Token);
            var endpoint = new NotificationEndpoint(client);

            var marked = await endpoint.MarkNotificationsViewedAsync(new List<string> { "322868553", "322866705" });

            Assert.IsFalse(marked);
        }
    }
}
