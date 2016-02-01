using System.Linq;
using System.Threading.Tasks;
using Imgur.API.Authentication.Impl;
using Imgur.API.Endpoints.Impl;
using Xunit;

// ReSharper disable ExceptionNotDocumented

namespace Imgur.API.Tests.Integration.Endpoints.AccountEndpointImageTests
{
    public class MashapeClientWithOAuth2Tests : TestBase
    {
        [Fact]
        [Trait("Category", "AccountEndpointImage")]
        public async Task DeleteImageAsync_ThrowsImgurException()
        {
            var client = new MashapeClient(Settings.ClientId, Settings.MashapeKey, OAuth2Token);
            var endpoint = new AccountEndpoint(client);

            var exception =
                await
                    Record.ExceptionAsync(
                        async () => await endpoint.DeleteImageAsync("ra06GZN", "sarah").ConfigureAwait(false))
                        .ConfigureAwait(false);
            Assert.NotNull(exception);
            Assert.IsType<ImgurException>(exception);
        }

        [Fact]
        [Trait("Category", "AccountEndpointImage")]
        public async Task GetImageAsync_NotNull()
        {
            var client = new MashapeClient(Settings.ClientId, Settings.MashapeKey, OAuth2Token);
            var endpoint = new AccountEndpoint(client);

            var image = await endpoint.GetImageAsync("BJRWQw5").ConfigureAwait(false);

            Assert.NotNull(image);
        }

        [Fact]
        [Trait("Category", "AccountEndpointImage")]
        public async Task GetImageCountAsync_Any()
        {
            var client = new MashapeClient(Settings.ClientId, Settings.MashapeKey, OAuth2Token);
            var endpoint = new AccountEndpoint(client);

            var imageCount = await endpoint.GetImageCountAsync().ConfigureAwait(false);

            Assert.True(imageCount > 1);
        }

        [Fact]
        [Trait("Category", "AccountEndpointImage")]
        public async Task GetImageIdsAsync_Any()
        {
            var client = new MashapeClient(Settings.ClientId, Settings.MashapeKey, OAuth2Token);
            var endpoint = new AccountEndpoint(client);

            var images = await endpoint.GetImageIdsAsync().ConfigureAwait(false);

            Assert.True(images.Count() > 1);
        }

        [Fact]
        [Trait("Category", "AccountEndpointImage")]
        public async Task GetImagesAsync_Any()
        {
            var client = new MashapeClient(Settings.ClientId, Settings.MashapeKey, OAuth2Token);
            var endpoint = new AccountEndpoint(client);

            var images = await endpoint.GetImagesAsync().ConfigureAwait(false);

            Assert.True(images.Any());
        }
    }
}