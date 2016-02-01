using System.Linq;
using System.Threading.Tasks;
using Imgur.API.Authentication.Impl;
using Imgur.API.Endpoints.Impl;
using Xunit;

// ReSharper disable ExceptionNotDocumented

namespace Imgur.API.Tests.Integration.Endpoints.GalleryEndpointSubredditTests
{
    public class MashapeClientTests : TestBase
    {
        [Fact]
        [Trait("Category", "GalleryEndpoint")]
        public async Task GetSubredditGalleryAsync_Any()
        {
            var client = new MashapeClient(Settings.ClientId, Settings.MashapeKey);
            var endpoint = new GalleryEndpoint(client);

            var subreddit = await endpoint.GetSubredditGalleryAsync("gaming").ConfigureAwait(false);

            Assert.True(subreddit.Any());
        }

        [Fact]
        [Trait("Category", "GalleryEndpoint")]
        public async Task GetSubredditImageAsync_NotNull()
        {
            var client = new MashapeClient(Settings.ClientId, Settings.MashapeKey);
            var endpoint = new GalleryEndpoint(client);

            var image = await endpoint.GetSubredditImageAsync("wPWniy2", "gaming").ConfigureAwait(false);

            Assert.NotNull(image);
        }
    }
}