using System.Linq;
using System.Threading.Tasks;
using Imgur.API.Authentication.Impl;
using Imgur.API.Endpoints.Impl;
using Xunit;

// ReSharper disable ExceptionNotDocumented

namespace Imgur.API.Tests.Integration.Endpoints.AccountEndpointCommentTests
{
    public class MashapeClientWithOAuth2Tests : TestBase
    {
        [Fact]
        [Trait("Category", "AccountEndpointComment")]
        public async Task DeleteCommentAsync_WithValidReponse_ThrowsImgurException()
        {
            var client = new MashapeClient(Settings.ClientId, Settings.ClientSecret, Settings.MashapeKey, OAuth2Token);
            var endpoint = new AccountEndpoint(client);

            var exception =
                await
                    Record.ExceptionAsync(async () => await endpoint.DeleteCommentAsync(487153732).ConfigureAwait(false))
                        .ConfigureAwait(false);
            Assert.NotNull(exception);
            Assert.IsType<ImgurException>(exception);
        }

        [Fact]
        [Trait("Category", "AccountEndpointComment")]
        public async Task GetCommentCountAsync_WithValidReponse_Equal()
        {
            var client = new MashapeClient(Settings.ClientId, Settings.ClientSecret, Settings.MashapeKey, OAuth2Token);
            var endpoint = new AccountEndpoint(client);

            var commentCount = await endpoint.GetCommentCountAsync().ConfigureAwait(false);

            Assert.True(commentCount > 1);
        }

        [Fact]
        [Trait("Category", "AccountEndpointComment")]
        public async Task GetCommentIdsAsync_Equal()
        {
            var client = new MashapeClient(Settings.ClientId, Settings.ClientSecret, Settings.MashapeKey, OAuth2Token);
            var endpoint = new AccountEndpoint(client);

            var comments = await endpoint.GetCommentIdsAsync().ConfigureAwait(false);

            Assert.True(comments.Count() > 1);
        }

        [Fact]
        [Trait("Category", "AccountEndpointComment")]
        public async Task GetCommentsAsync_Equal()
        {
            var client = new MashapeClient(Settings.ClientId, Settings.ClientSecret, Settings.MashapeKey, OAuth2Token);
            var endpoint = new AccountEndpoint(client);

            var comments = await endpoint.GetCommentsAsync().ConfigureAwait(false);

            Assert.True(comments.Count() >= 2);
        }
    }
}