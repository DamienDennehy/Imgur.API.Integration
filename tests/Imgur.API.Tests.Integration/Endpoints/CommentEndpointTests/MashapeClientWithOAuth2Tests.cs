using System.Linq;
using System.Threading.Tasks;
using Imgur.API.Authentication.Impl;
using Imgur.API.Endpoints.Impl;
using Imgur.API.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// ReSharper disable ExceptionNotDocumented

namespace Imgur.API.Tests.Integration.Endpoints.CommentEndpointTests
{
    [TestClass]
    public class MashapeClientWithOAuth2Tests : TestBase
    {
        [TestMethod]
        [TestCategory("CommentEndpoint")]
        public async Task GetCommentAsync_AreEqual()
        {
            var client = new MashapeClient(ClientId, ClientSecret, MashapeKey, OAuth2Token);
            var endpoint = new CommentEndpoint(client);

            var comment = await endpoint.GetCommentAsync("540468501").ConfigureAwait(false);

            Assert.IsNotNull(comment);
            Assert.AreEqual(540468501, comment.Id);
        }

        [TestMethod]
        [TestCategory("CommentEndpoint")]
        public async Task GetRepliesAsync_AnyChildren()
        {
            var client = new MashapeClient(ClientId, ClientSecret, MashapeKey, OAuth2Token);
            var endpoint = new CommentEndpoint(client);

            var comment = await endpoint.GetRepliesAsync("540468501").ConfigureAwait(false);

            Assert.IsNotNull(comment);
            Assert.IsTrue(comment.Children.Any());
        }

        [TestMethod]
        [TestCategory("CommentEndpoint")]
        public async Task CreateCommentAsync_IsNotNull()
        {
            var client = new MashapeClient(ClientId, ClientSecret, MashapeKey, OAuth2Token);
            var endpoint = new CommentEndpoint(client);

            var comment = await endpoint.CreateCommentAsync("Create Comment", "BJRWQw5").ConfigureAwait(false);

            Assert.IsNotNull(comment);
        }

        [TestMethod]
        [TestCategory("CommentEndpoint")]
        public async Task CreateCommentAsync_WithParentId_IsNotNull()
        {
            var client = new MashapeClient(ClientId, ClientSecret, MashapeKey, OAuth2Token);
            var endpoint = new CommentEndpoint(client);

            var comment =
                await
                    endpoint.CreateCommentAsync("Create Comment with Parent", "BJRWQw5", "540767605")
                        .ConfigureAwait(false);

            Assert.IsNotNull(comment);
        }

        [TestMethod]
        [TestCategory("CommentEndpoint")]
        public async Task CreateReplyAsync_IsTrue()
        {
            var client = new MashapeClient(ClientId, ClientSecret, MashapeKey, OAuth2Token);
            var endpoint = new CommentEndpoint(client);

            var comment = await endpoint.CreateReplyAsync("Create Reply", "BJRWQw5", "540767605").ConfigureAwait(false);

            Assert.IsTrue(comment > 0);
        }

        [TestMethod]
        [TestCategory("CommentEndpoint")]
        public async Task DeleteCommentAsync_IsTrue()
        {
            var client = new MashapeClient(ClientId, ClientSecret, MashapeKey, OAuth2Token);
            var endpoint = new CommentEndpoint(client);

            var commentId = await endpoint.CreateCommentAsync("Create Comment", "BJRWQw5").ConfigureAwait(false);
            var deleted = await endpoint.DeleteCommentAsync(commentId.ToString()).ConfigureAwait(false);

            Assert.IsTrue(deleted);
        }

        [TestMethod]
        [TestCategory("CommentEndpoint")]
        public async Task VoteCommentAsync_IsTrue()
        {
            var client = new ImgurClient(ClientId, ClientSecret, OAuth2Token);
            var endpoint = new CommentEndpoint(client);

            var commentId = await endpoint.CreateCommentAsync("Create Comment", "BJRWQw5").ConfigureAwait(false);
            var comment = await endpoint.GetCommentAsync(commentId.ToString()).ConfigureAwait(false);

            Assert.AreEqual(VoteOption.Up, comment.Vote);

            var voted = await endpoint.VoteCommentAsync(commentId.ToString(), VoteOption.Down).ConfigureAwait(false);
            comment = await endpoint.GetCommentAsync(commentId.ToString()).ConfigureAwait(false);

            Assert.IsNotNull(voted);
        }
    }
}