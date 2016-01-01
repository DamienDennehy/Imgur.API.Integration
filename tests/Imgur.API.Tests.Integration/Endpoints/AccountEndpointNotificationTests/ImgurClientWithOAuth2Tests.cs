using System.Linq;
using System.Threading.Tasks;
using Imgur.API.Authentication.Impl;
using Imgur.API.Endpoints.Impl;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// ReSharper disable ExceptionNotDocumented

namespace Imgur.API.Tests.Integration.Endpoints.AccountEndpointNotificationTests
{
    [TestClass]
    public class ImgurClientWithOAuth2Tests : TestBase
    {
        [TestMethod]
        [TestCategory("AccountEndpointNotification")]
        public async Task GetNotificationsAsync_AnyComments()
        {
            var client = new ImgurClient(ClientId, ClientSecret, OAuth2Token);
            var endpoint = new AccountEndpoint(client);

            var notifications = await endpoint.GetNotificationsAsync(false).ConfigureAwait(false);

            Assert.IsNotNull(notifications);
            Assert.IsTrue(notifications.Replies.Any());
        }
    }
}