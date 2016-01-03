using System.Linq;
using System.Threading.Tasks;
using Imgur.API.Authentication.Impl;
using Imgur.API.Endpoints.Impl;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// ReSharper disable ExceptionNotDocumented

namespace Imgur.API.Tests.Integration.Endpoints.CommentEndpointTests
{
    [TestClass]
    public class ImgurClientTests : TestBase
    {
        [TestMethod]
        [TestCategory("CommentEndpoint")]
        public async Task GetCommentAsync_AreEqual()
        {
            var client = new ImgurClient(ClientId, ClientSecret);
            var endpoint = new CommentEndpoint(client);

            var comment = await endpoint.GetCommentAsync(540468501).ConfigureAwait(false);

            Assert.IsNotNull(comment);
            Assert.AreEqual(540468501, comment.Id);
        }

        [TestMethod]
        [TestCategory("CommentEndpoint")]
        public async Task GetRepliesAsync_AnyChildren()
        {
            var client = new ImgurClient(ClientId, ClientSecret);
            var endpoint = new CommentEndpoint(client);

            var comment = await endpoint.GetRepliesAsync(540468501).ConfigureAwait(false);

            Assert.IsNotNull(comment);
            Assert.IsTrue(comment.Children.Any());
        }
    }
}