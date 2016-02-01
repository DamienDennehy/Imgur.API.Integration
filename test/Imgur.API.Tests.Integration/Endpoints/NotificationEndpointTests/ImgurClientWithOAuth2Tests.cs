using System.Collections.Generic;
using System.Threading.Tasks;
using Imgur.API.Authentication.Impl;
using Imgur.API.Endpoints.Impl;
using Xunit;

// ReSharper disable ExceptionNotDocumented

namespace Imgur.API.Tests.Integration.Endpoints.NotificationEndpointTests
{
    public class ImgurClientWithOAuth2Tests : TestBase
    {
        [Fact]
        [Trait("Category", "NotificationEndpoint")]
        public async Task GetNotificationsAsync_Equal()
        {
            var client = new ImgurClient(Settings.ClientId, OAuth2Token);
            var endpoint = new NotificationEndpoint(client);

            var notifications = await endpoint.GetNotificationsAsync().ConfigureAwait(false);

            Assert.NotNull(notifications);
        }

        [Fact]
        [Trait("Category", "NotificationEndpoint")]
        public async Task GetNotificationAsync_Equal()
        {
            var client = new ImgurClient(Settings.ClientId, OAuth2Token);
            var endpoint = new NotificationEndpoint(client);

            var notification = await endpoint.GetNotificationAsync("322888961").ConfigureAwait(false);

            Assert.NotNull(notification);
        }

        [Fact]
        [Trait("Category", "NotificationEndpoint")]
        public async Task MarkNotificationViewedAsync_False()
        {
            var client = new ImgurClient(Settings.ClientId, OAuth2Token);
            var endpoint = new NotificationEndpoint(client);

            var marked = await endpoint.MarkNotificationViewedAsync("322888961").ConfigureAwait(false);

            Assert.False(marked);
        }

        [Fact]
        [Trait("Category", "NotificationEndpoint")]
        public async Task MarkNotificationsViewedAsync_False()
        {
            var client = new ImgurClient(Settings.ClientId, OAuth2Token);
            var endpoint = new NotificationEndpoint(client);

            var marked =
                await
                    endpoint.MarkNotificationsViewedAsync(new List<string> {"322868553", "322866705"})
                        .ConfigureAwait(false);

            Assert.False(marked);
        }
    }
}