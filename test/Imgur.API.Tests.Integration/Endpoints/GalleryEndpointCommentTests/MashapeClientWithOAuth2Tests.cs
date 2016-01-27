using System.Threading.Tasks;
using Imgur.API.Authentication.Impl;
using Imgur.API.Endpoints.Impl;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// ReSharper disable ExceptionNotDocumented

namespace Imgur.API.Tests.Integration.Endpoints.GalleryEndpointCommentTests
{
    [TestClass]
    public class MashapeClientWithOAuth2Tests : TestBase
    {
        [TestMethod]
        [TestCategory("GalleryEndpoint")]
        public async Task CreateGalleryItemCommentAsync_IsNotNull()
        {
            var client = new MashapeClient(ClientId, ClientSecret, MashapeKey, OAuth2Token);
            var endpoint = new GalleryEndpoint(client);

            var comment = await endpoint.CreateGalleryItemCommentAsync("Create Comment from Gallery", "BJRWQw5").ConfigureAwait(false);

            Assert.IsNotNull(comment);
        }

        [TestMethod]
        [TestCategory("GalleryEndpoint")]
        public async Task CreateGalleryItemCommentReplyAsync_IsNotNull()
        {
            var client = new MashapeClient(ClientId, ClientSecret, MashapeKey, OAuth2Token);
            var endpoint = new GalleryEndpoint(client);

            var comment = await endpoint.CreateGalleryItemCommentReplyAsync("Reply Comment from Gallery", "BJRWQw5", "550061341").ConfigureAwait(false);

            Assert.IsNotNull(comment);
        }
    }
}