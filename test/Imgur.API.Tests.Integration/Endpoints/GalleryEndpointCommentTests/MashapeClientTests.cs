using System.Linq;
using System.Threading.Tasks;
using Imgur.API.Authentication.Impl;
using Imgur.API.Endpoints.Impl;
using Xunit;

// ReSharper disable ExceptionNotDocumented

namespace Imgur.API.Tests.Integration.Endpoints.GalleryEndpointCommentTests
{
    public class MashapeClientTests : TestBase
    {
        [Fact]
        [Trait("Category", "GalleryEndpoint")]
        public async Task GetGalleryItemCommentAsync_NotNull()
        {
            var client = new MashapeClient(Settings.ClientId, Settings.ClientSecret, Settings.MashapeKey);
            var endpoint = new GalleryEndpoint(client);

            var comment = await endpoint.GetGalleryItemCommentAsync(542787274, "9cYFV").ConfigureAwait(false);

            Assert.NotNull(comment);
        }

        [Fact]
        [Trait("Category", "GalleryEndpoint")]
        public async Task GetGalleryItemCommentCountAsync_True()
        {
            var client = new MashapeClient(Settings.ClientId, Settings.ClientSecret, Settings.MashapeKey);
            var endpoint = new GalleryEndpoint(client);

            var commentCount = await endpoint.GetGalleryItemCommentCountAsync("9cYFV").ConfigureAwait(false);

            Assert.True(commentCount > 10);
        }

        [Fact]
        [Trait("Category", "GalleryEndpoint")]
        public async Task GetGalleryItemCommentIdsAsync_True()
        {
            var client = new MashapeClient(Settings.ClientId, Settings.ClientSecret, Settings.MashapeKey);
            var endpoint = new GalleryEndpoint(client);

            var commentIds = await endpoint.GetGalleryItemCommentIdsAsync("9cYFV").ConfigureAwait(false);

            Assert.True(commentIds.Count() > 10);
        }

        [Fact]
        [Trait("Category", "GalleryEndpoint")]
        public async Task GetGalleryItemCommentsAsync_True()
        {
            var client = new MashapeClient(Settings.ClientId, Settings.ClientSecret, Settings.MashapeKey);
            var endpoint = new GalleryEndpoint(client);

            var comments = await endpoint.GetGalleryItemCommentsAsync("9cYFV").ConfigureAwait(false);

            Assert.True(comments.Count() > 10);
        }
    }
}