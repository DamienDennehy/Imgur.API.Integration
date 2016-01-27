using System.Linq;
using System.Threading.Tasks;
using Imgur.API.Authentication.Impl;
using Imgur.API.Endpoints.Impl;
using Imgur.API.Enums;
using Xunit;

// ReSharper disable ExceptionNotDocumented

namespace Imgur.API.Tests.Integration.Endpoints.CommentEndpointTests
{
    public class MashapeClientWithOAuth2Tests : TestBase
    {
        [Fact]
        [Trait("Category", "CommentEndpoint")]
        public async Task GetCommentAsync_Equal()
        {
            var client = new MashapeClient(Settings.ClientId, Settings.ClientSecret, Settings.MashapeKey, OAuth2Token);
            var endpoint = new CommentEndpoint(client);

            var comment = await endpoint.GetCommentAsync(540468501).ConfigureAwait(false);

            Assert.NotNull(comment);
            Assert.Equal(540468501, comment.Id);
        }

        [Fact]
        [Trait("Category", "CommentEndpoint")]
        public async Task GetRepliesAsync_AnyChildren()
        {
            var client = new MashapeClient(Settings.ClientId, Settings.ClientSecret, Settings.MashapeKey, OAuth2Token);
            var endpoint = new CommentEndpoint(client);

            var comment = await endpoint.GetRepliesAsync(540468501).ConfigureAwait(false);

            Assert.NotNull(comment);
            Assert.True(comment.Children.Any());
        }

        [Fact]
        [Trait("Category", "CommentEndpoint")]
        public async Task CreateCommentAsync_NotNull()
        {
            var client = new MashapeClient(Settings.ClientId, Settings.ClientSecret, Settings.MashapeKey, OAuth2Token);
            var endpoint = new CommentEndpoint(client);

            var comment = await endpoint.CreateCommentAsync("Create Comment", "BJRWQw5").ConfigureAwait(false);

            Assert.NotNull(comment);
        }

        [Fact]
        [Trait("Category", "CommentEndpoint")]
        public async Task CreateCommentAsync_WithParentId_NotNull()
        {
            var client = new MashapeClient(Settings.ClientId, Settings.ClientSecret, Settings.MashapeKey, OAuth2Token);
            var endpoint = new CommentEndpoint(client);

            var comment =
                await
                    endpoint.CreateCommentAsync("Create Comment with Parent", "BJRWQw5", "540767605")
                        .ConfigureAwait(false);

            Assert.NotNull(comment);
        }

        [Fact]
        [Trait("Category", "CommentEndpoint")]
        public async Task CreateReplyAsync_True()
        {
            var client = new MashapeClient(Settings.ClientId, Settings.ClientSecret, Settings.MashapeKey, OAuth2Token);
            var endpoint = new CommentEndpoint(client);

            var comment = await endpoint.CreateReplyAsync("Create Reply", "BJRWQw5", "540767605").ConfigureAwait(false);

            Assert.True(comment > 0);
        }

        [Fact]
        [Trait("Category", "CommentEndpoint")]
        public async Task DeleteCommentAsync_True()
        {
            var client = new MashapeClient(Settings.ClientId, Settings.ClientSecret, Settings.MashapeKey, OAuth2Token);
            var endpoint = new CommentEndpoint(client);

            var commentId = await endpoint.CreateCommentAsync("Create Comment", "BJRWQw5").ConfigureAwait(false);
            var deleted = await endpoint.DeleteCommentAsync(commentId).ConfigureAwait(false);

            Assert.True(deleted);
        }

        [Fact]
        [Trait("Category", "CommentEndpoint")]
        public async Task VoteCommentAsync_True()
        {
            var client = new ImgurClient(Settings.ClientId, Settings.ClientSecret, OAuth2Token);
            var endpoint = new CommentEndpoint(client);

            var commentId = await endpoint.CreateCommentAsync("Create Comment", "BJRWQw5").ConfigureAwait(false);
            var comment = await endpoint.GetCommentAsync(commentId).ConfigureAwait(false);

            Assert.Equal(VoteOption.Up, comment.Vote);

            var voted = await endpoint.VoteCommentAsync(commentId, VoteOption.Down).ConfigureAwait(false);
            comment = await endpoint.GetCommentAsync(commentId).ConfigureAwait(false);

            Assert.NotNull(voted);
            Assert.NotNull(comment.Vote);
        }
    }
}