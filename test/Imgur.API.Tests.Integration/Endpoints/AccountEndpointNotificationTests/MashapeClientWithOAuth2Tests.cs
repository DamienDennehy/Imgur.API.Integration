using System.Linq;
using System.Threading.Tasks;
using Imgur.API.Authentication.Impl;
using Imgur.API.Endpoints.Impl;
using Xunit;

// ReSharper disable ExceptionNotDocumented

namespace Imgur.API.Tests.Integration.Endpoints.AccountEndpointNotificationTests
{
    public class MashapeClientWithOAuth2Tests : TestBase
    {
        [Fact]
        [Trait("Category", "AccountEndpointNotification")]
        public async Task GetNotificationsAsync_AnyComments()
        {
            var client = new ImgurClient(Settings.ClientId, Settings.ClientSecret, OAuth2Token);
            var endpoint = new AccountEndpoint(client);

            var notifications = await endpoint.GetNotificationsAsync(false).ConfigureAwait(false);

            Assert.NotNull(notifications);
            Assert.True(notifications.Replies.Any());
        }
    }
}