using System.Linq;
using System.Threading.Tasks;
using Imgur.API.Authentication.Impl;
using Imgur.API.Endpoints.Impl;
using Imgur.API.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// ReSharper disable ExceptionNotDocumented

namespace Imgur.API.Tests.Integration.Endpoints.TopicEndpointTests
{
    [TestClass]
    public class ImgurClientTests : TestBase
    {
        [TestMethod]
        [TestCategory("TopicEndpoint")]
        public async Task GetDefaultTopicsAsync_Any()
        {
            var client = new ImgurClient(ClientId, ClientSecret);
            var endpoint = new TopicEndpoint(client);

            var topics = await endpoint.GetDefaultTopicsAsync().ConfigureAwait(false);

            Assert.IsTrue(topics.Any());
        }

        [TestMethod]
        [TestCategory("TopicEndpoint")]
        public async Task GetGalleryTopicItemsAsync_Any()
        {
            var client = new ImgurClient(ClientId, ClientSecret);
            var endpoint = new TopicEndpoint(client);

            var items =
                await
                    endpoint.GetGalleryTopicItemsAsync("Current Events", CustomGallerySortOrder.Top, TimeWindow.Day)
                        .ConfigureAwait(false);

            Assert.IsTrue(items.Any());
        }

        [TestMethod]
        [TestCategory("TopicEndpoint")]
        public async Task GetGalleryTopicItemAsync_IsNotNull()
        {
            var client = new ImgurClient(ClientId, ClientSecret);
            var endpoint = new TopicEndpoint(client);

            var item = await endpoint.GetGalleryTopicItemAsync("bjeTa", "Current Events").ConfigureAwait(false);

            Assert.IsNotNull(item);
        }
    }
}