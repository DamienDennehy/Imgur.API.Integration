using System.Linq;
using System.Threading.Tasks;
using Imgur.API.Authentication.Impl;
using Imgur.API.Endpoints.Impl;
using Xunit;

// ReSharper disable ExceptionNotDocumented

namespace Imgur.API.Tests.Integration.Endpoints.AccountEndpointAlbumTests
{
    public class MashapeClientWithOAuth2Tests : TestBase
    {
        [Fact]
        [Trait("Category", "AccountEndpointAlbum")]
        public async Task DeleteAlbumAsync_ThrowsImgurException()
        {
            var client = new MashapeClient(Settings.ClientId, Settings.MashapeKey, OAuth2Token);
            var endpoint = new AccountEndpoint(client);

            var exception =
                await
                    Record.ExceptionAsync(
                        async () => await endpoint.DeleteAlbumAsync("lzpoZ7a5IPrxvVe").ConfigureAwait(false))
                        .ConfigureAwait(false);
            Assert.NotNull(exception);
            Assert.IsType<ImgurException>(exception);
        }

        [Fact]
        [Trait("Category", "AccountEndpointAlbum")]
        public async Task GetAlbumAsync_WithValidReponse_Equal()
        {
            var client = new MashapeClient(Settings.ClientId, Settings.MashapeKey, OAuth2Token);
            var endpoint = new AccountEndpoint(client);

            var album = await endpoint.GetAlbumAsync("cuta6").ConfigureAwait(false);

            Assert.NotNull(album);
        }

        [Fact]
        [Trait("Category", "AccountEndpointAlbum")]
        public async Task GetAlbumCountAsync_WithValidReponse_Equal()
        {
            var client = new MashapeClient(Settings.ClientId, Settings.MashapeKey, OAuth2Token);
            var endpoint = new AccountEndpoint(client);

            var albums = await endpoint.GetAlbumCountAsync().ConfigureAwait(false);

            Assert.True(albums >= 1);
        }

        [Fact]
        [Trait("Category", "AccountEndpointAlbum")]
        public async Task GetAlbumIdsAsync_Any()
        {
            var client = new MashapeClient(Settings.ClientId, Settings.MashapeKey, OAuth2Token);
            var endpoint = new AccountEndpoint(client);

            var albums = await endpoint.GetAlbumIdsAsync().ConfigureAwait(false);

            Assert.True(albums.Any());
        }

        [Fact]
        [Trait("Category", "AccountEndpointAlbum")]
        public async Task GetAlbumsAsync_True()
        {
            var client = new MashapeClient(Settings.ClientId, Settings.MashapeKey, OAuth2Token);
            var endpoint = new AccountEndpoint(client);

            var albums = await endpoint.GetAlbumsAsync().ConfigureAwait(false);

            Assert.True(albums.Any());
        }
    }
}