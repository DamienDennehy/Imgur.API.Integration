using System.Linq;
using System.Threading.Tasks;
using Imgur.API.Authentication.Impl;
using Imgur.API.Endpoints.Impl;
using Imgur.API.Enums;
using Xunit;

// ReSharper disable ExceptionNotDocumented

namespace Imgur.API.Tests.Integration.Endpoints.TopicEndpointTests
{
    public class ImgurClientTests : TestBase
    {
        [Fact]
        [Trait("Category", "TopicEndpoint")]
        public async Task GetDefaultTopicsAsync_Any()
        {
            var client = new ImgurClient(Settings.ClientId);
            var endpoint = new TopicEndpoint(client);

            var topics = await endpoint.GetDefaultTopicsAsync().ConfigureAwait(false);

            Assert.True(topics.Any());
        }

        [Fact]
        [Trait("Category", "TopicEndpoint")]
        public async Task GetGalleryTopicItemsAsync_Any()
        {
            var client = new ImgurClient(Settings.ClientId);
            var endpoint = new TopicEndpoint(client);

            var items =
                await
                    endpoint.GetGalleryTopicItemsAsync("Current Events", CustomGallerySortOrder.Top, TimeWindow.Day)
                        .ConfigureAwait(false);

            Assert.True(items.Any());
        }

        [Fact]
        [Trait("Category", "TopicEndpoint")]
        public async Task GetGalleryTopicItemAsync_NotNull()
        {
            var client = new ImgurClient(Settings.ClientId);
            var endpoint = new TopicEndpoint(client);

            var item = await endpoint.GetGalleryTopicItemAsync("bjeTa", "Current Events").ConfigureAwait(false);

            Assert.NotNull(item);
        }
    }
}