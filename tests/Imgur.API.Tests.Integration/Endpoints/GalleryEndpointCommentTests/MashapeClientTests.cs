using System.Linq;
using System.Threading.Tasks;
using Imgur.API.Authentication.Impl;
using Imgur.API.Endpoints.Impl;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// ReSharper disable ExceptionNotDocumented

namespace Imgur.API.Tests.Integration.Endpoints.GalleryEndpointCommentTests
{
    [TestClass]
    public class MashapeClientTests : TestBase
    {
        [TestMethod]
        [TestCategory("GalleryEndpoint")]
        public async Task GetGalleryItemCommentAsync_IsNotNull()
        {
            var client = new MashapeClient(ClientId, ClientSecret, MashapeKey);
            var endpoint = new GalleryEndpoint(client);

            var comment = await endpoint.GetGalleryItemCommentAsync("542787274", "9cYFV").ConfigureAwait(false);

            Assert.IsNotNull(comment);
        }

        [TestMethod]
        [TestCategory("GalleryEndpoint")]
        public async Task GetGalleryItemCommentCountAsync_IsTrue()
        {
            var client = new MashapeClient(ClientId, ClientSecret, MashapeKey);
            var endpoint = new GalleryEndpoint(client);

            var commentCount = await endpoint.GetGalleryItemCommentCountAsync("9cYFV").ConfigureAwait(false);

            Assert.IsTrue(commentCount > 10);
        }

        [TestMethod]
        [TestCategory("GalleryEndpoint")]
        public async Task GetGalleryItemCommentIdsAsync_IsTrue()
        {
            var client = new MashapeClient(ClientId, ClientSecret, MashapeKey);
            var endpoint = new GalleryEndpoint(client);

            var commentIds = await endpoint.GetGalleryItemCommentIdsAsync("9cYFV").ConfigureAwait(false);

            Assert.IsTrue(commentIds.Count() > 10);
        }

        [TestMethod]
        [TestCategory("GalleryEndpoint")]
        public async Task GetGalleryItemCommentsAsync_IsTrue()
        {
            var client = new MashapeClient(ClientId, ClientSecret, MashapeKey);
            var endpoint = new GalleryEndpoint(client);

            var comments = await endpoint.GetGalleryItemCommentsAsync("9cYFV").ConfigureAwait(false);

            Assert.IsTrue(comments.Count() > 10);
        }
    }
}