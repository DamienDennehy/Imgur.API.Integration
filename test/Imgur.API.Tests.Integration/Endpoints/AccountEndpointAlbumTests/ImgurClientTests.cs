using System.Linq;
using System.Threading.Tasks;
using Imgur.API.Authentication.Impl;
using Imgur.API.Endpoints.Impl;
using Xunit;

// ReSharper disable ExceptionNotDocumented

namespace Imgur.API.Tests.Integration.Endpoints.AccountEndpointAlbumTests
{
    public class ImgurClientTests : TestBase
    {
        [Fact]
        [Trait("Category", "AccountEndpointAlbum")]
        public async Task GetAlbumAsync_NotNull()
        {
            var client = new ImgurClient(Settings.ClientId);
            var endpoint = new AccountEndpoint(client);

            var album = await endpoint.GetAlbumAsync("SbU9Y", "sarah").ConfigureAwait(false);

            Assert.NotNull(album);
        }

        [Fact]
        [Trait("Category", "AccountEndpointAlbum")]
        public async Task GetAlbumCountAsync_GreaterThan100()
        {
            var client = new ImgurClient(Settings.ClientId);
            var endpoint = new AccountEndpoint(client);

            var albums = await endpoint.GetAlbumCountAsync("sarah").ConfigureAwait(false);

            Assert.True(albums > 100);
        }

        [Fact]
        [Trait("Category", "AccountEndpointAlbum")]
        public async Task GetAlbumIdsAsync_Equal()
        {
            var client = new ImgurClient(Settings.ClientId);
            var endpoint = new AccountEndpoint(client);

            var albums = await endpoint.GetAlbumIdsAsync("sarah").ConfigureAwait(false);

            Assert.Equal(50, albums.Count());
        }

        [Fact]
        [Trait("Category", "AccountEndpointAlbum")]
        public async Task GetAlbumsAsync_Equal()
        {
            var client = new ImgurClient(Settings.ClientId);
            var endpoint = new AccountEndpoint(client);

            var albums = await endpoint.GetAlbumsAsync("sarah").ConfigureAwait(false);

            Assert.Equal(50, albums.Count());
        }
    }
}