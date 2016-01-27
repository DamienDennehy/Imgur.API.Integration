using System.Linq;
using System.Threading.Tasks;
using Imgur.API.Authentication.Impl;
using Imgur.API.Endpoints.Impl;
using Imgur.API.Enums;
using Xunit;

// ReSharper disable ExceptionNotDocumented

namespace Imgur.API.Tests.Integration.Endpoints.AccountEndpointCommentTests
{
    public class MashapeClientTests : TestBase
    {
        [Fact]
        [Trait("Category", "AccountEndpointComment")]
        public async Task GetCommentAsync_Equal()
        {
            var client = new MashapeClient(Settings.ClientId, Settings.ClientSecret, Settings.MashapeKey);
            var endpoint = new AccountEndpoint(client);

            var comment = await endpoint.GetCommentAsync(300731088, "sarah").ConfigureAwait(false);

            Assert.NotNull(comment);
        }

        [Fact]
        [Trait("Category", "AccountEndpointComment")]
        public async Task GetCommentCountAsync_Equal()
        {
            var client = new MashapeClient(Settings.ClientId, Settings.ClientSecret, Settings.MashapeKey);
            var endpoint = new AccountEndpoint(client);

            var commentCount = await endpoint.GetCommentCountAsync("sarah").ConfigureAwait(false);

            Assert.True(commentCount > 100);
        }

        [Fact]
        [Trait("Category", "AccountEndpointComment")]
        public async Task GetCommentIdsAsync_Equal()
        {
            var client = new MashapeClient(Settings.ClientId, Settings.ClientSecret, Settings.MashapeKey);
            var endpoint = new AccountEndpoint(client);

            var comments = await endpoint.GetCommentIdsAsync("sarah").ConfigureAwait(false);

            Assert.Equal(50, comments.Count());
        }

        [Fact]
        [Trait("Category", "AccountEndpointComment")]
        public async Task GetCommentsAsync_Equal()
        {
            var client = new MashapeClient(Settings.ClientId, Settings.ClientSecret, Settings.MashapeKey);
            var endpoint = new AccountEndpoint(client);

            var comments = await endpoint.GetCommentsAsync("sarah", CommentSortOrder.Best).ConfigureAwait(false);

            Assert.Equal(50, comments.Count());
        }
    }
}