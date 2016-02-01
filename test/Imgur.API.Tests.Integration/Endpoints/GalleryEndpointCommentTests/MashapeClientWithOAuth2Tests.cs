using System.Threading.Tasks;
using Imgur.API.Authentication.Impl;
using Imgur.API.Endpoints.Impl;
using Xunit;

// ReSharper disable ExceptionNotDocumented

namespace Imgur.API.Tests.Integration.Endpoints.GalleryEndpointCommentTests
{
    public class MashapeClientWithOAuth2Tests : TestBase
    {
        [Fact]
        [Trait("Category", "GalleryEndpoint")]
        public async Task CreateGalleryItemCommentAsync_NotNull()
        {
            var client = new MashapeClient(Settings.ClientId, Settings.MashapeKey, OAuth2Token);
            var endpoint = new GalleryEndpoint(client);

            var comment =
                await
                    endpoint.CreateGalleryItemCommentAsync("Create Comment from Gallery", "BJRWQw5")
                        .ConfigureAwait(false);

            Assert.NotNull(comment);
        }

        [Fact]
        [Trait("Category", "GalleryEndpoint")]
        public async Task CreateGalleryItemCommentReplyAsync_NotNull()
        {
            var client = new MashapeClient(Settings.ClientId, Settings.MashapeKey, OAuth2Token);
            var endpoint = new GalleryEndpoint(client);

            var comment =
                await
                    endpoint.CreateGalleryItemCommentReplyAsync("Reply Comment from Gallery", "BJRWQw5", "550061341")
                        .ConfigureAwait(false);

            Assert.NotNull(comment);
        }
    }
}