using System.Linq;
using System.Threading.Tasks;
using Imgur.API.Authentication.Impl;
using Imgur.API.Endpoints.Impl;
using Xunit;

// ReSharper disable ExceptionNotDocumented

namespace Imgur.API.Tests.Integration.Endpoints.CommentEndpointTests
{
    public class MashapeClientTests : TestBase
    {
        [Fact]
        [Trait("Category", "CommentEndpoint")]
        public async Task GetCommentAsync_Equal()
        {
            var client = new MashapeClient(Settings.ClientId, Settings.ClientSecret, Settings.MashapeKey);
            var endpoint = new CommentEndpoint(client);

            var comment = await endpoint.GetCommentAsync(540468501).ConfigureAwait(false);

            Assert.NotNull(comment);
            Assert.Equal(540468501, comment.Id);
        }

        [Fact]
        [Trait("Category", "CommentEndpoint")]
        public async Task GetRepliesAsync_AnyChildren()
        {
            var client = new MashapeClient(Settings.ClientId, Settings.ClientSecret, Settings.MashapeKey);
            var endpoint = new CommentEndpoint(client);

            var comment = await endpoint.GetRepliesAsync(540468501).ConfigureAwait(false);

            Assert.NotNull(comment);
            Assert.True(comment.Children.Any());
        }
    }
}