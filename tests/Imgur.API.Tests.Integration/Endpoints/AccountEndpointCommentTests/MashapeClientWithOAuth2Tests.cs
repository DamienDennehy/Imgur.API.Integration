using System.Linq;
using System.Threading.Tasks;
using Imgur.API.Authentication.Impl;
using Imgur.API.Endpoints.Impl;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// ReSharper disable ExceptionNotDocumented

namespace Imgur.API.Tests.Integration.Endpoints.AccountEndpointCommentTests
{
    [TestClass]
    public class MashapeClientWithOAuth2Tests : TestBase
    {
        [TestMethod]
        [TestCategory("AccountEndpointComment")]
        [ExpectedException(typeof (ImgurException))]
        public async Task DeleteCommentAsync_WithValidReponse_ThrowsImgurException()
        {
            var client = new MashapeClient(ClientId, ClientSecret, MashapeKey, OAuth2Token);
            var endpoint = new AccountEndpoint(client);

            var deleted = await endpoint.DeleteCommentAsync("487153732").ConfigureAwait(false);

            Assert.IsTrue(deleted);
        }

        [TestMethod]
        [TestCategory("AccountEndpointComment")]
        public async Task GetCommentCountAsync_WithValidReponse_AreEqual()
        {
            var client = new MashapeClient(ClientId, ClientSecret, MashapeKey, OAuth2Token);
            var endpoint = new AccountEndpoint(client);

            var commentCount = await endpoint.GetCommentCountAsync().ConfigureAwait(false);

            Assert.IsTrue(commentCount > 1);
        }

        [TestMethod]
        [TestCategory("AccountEndpointComment")]
        public async Task GetCommentIdsAsync_AreEqual()
        {
            var client = new MashapeClient(ClientId, ClientSecret, MashapeKey, OAuth2Token);
            var endpoint = new AccountEndpoint(client);

            var comments = await endpoint.GetCommentIdsAsync().ConfigureAwait(false);

            Assert.IsTrue(comments.Count() > 1);
        }

        [TestMethod]
        [TestCategory("AccountEndpointComment")]
        public async Task GetCommentsAsync_AreEqual()
        {
            var client = new MashapeClient(ClientId, ClientSecret, MashapeKey, OAuth2Token);
            var endpoint = new AccountEndpoint(client);

            var comments = await endpoint.GetCommentsAsync().ConfigureAwait(false);

            Assert.IsTrue(comments.Count() >= 2);
        }
    }
}