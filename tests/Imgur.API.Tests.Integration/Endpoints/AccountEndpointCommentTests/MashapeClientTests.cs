using System.Linq;
using System.Threading.Tasks;
using Imgur.API.Authentication.Impl;
using Imgur.API.Endpoints.Impl;
using Imgur.API.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Imgur.API.Tests.Integration.Endpoints.AccountEndpointCommentTests
{
    [TestClass]
    public class MashapeClientTests : TestBase
    {
        [TestMethod]
        [TestCategory("AccountEndpointComment")]
        public async Task GetCommentAsync_AreEqual()
        {
            var client = new MashapeClient(ClientId, ClientSecret, MashapeKey);
            var endpoint = new AccountEndpoint(client);

            var comment = await endpoint.GetCommentAsync("300731088", "sarah");

            Assert.IsNotNull(comment);
        }

        [TestMethod]
        [TestCategory("AccountEndpointComment")]
        public async Task GetCommentCountAsync_AreEqual()
        {
            var client = new MashapeClient(ClientId, ClientSecret, MashapeKey);
            var endpoint = new AccountEndpoint(client);

            var commentCount = await endpoint.GetCommentCountAsync("sarah");

            Assert.IsTrue(commentCount > 100);
        }

        [TestMethod]
        [TestCategory("AccountEndpointComment")]
        public async Task GetCommentIdsAsync_AreEqual()
        {
            var client = new MashapeClient(ClientId, ClientSecret, MashapeKey);
            var endpoint = new AccountEndpoint(client);

            var comments = await endpoint.GetCommentIdsAsync("sarah");

            Assert.AreEqual(50, comments.Count());
        }

        [TestMethod]
        [TestCategory("AccountEndpointComment")]
        public async Task GetCommentsAsync_AreEqual()
        {
            var client = new MashapeClient(ClientId, ClientSecret, MashapeKey);
            var endpoint = new AccountEndpoint(client);

            var comments = await endpoint.GetCommentsAsync("sarah", CommentSortOrder.Best);

            Assert.AreEqual(50, comments.Count());
        }
    }
}