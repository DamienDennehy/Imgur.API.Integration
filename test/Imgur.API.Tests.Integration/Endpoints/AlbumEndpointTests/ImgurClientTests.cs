using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Imgur.API.Authentication.Impl;
using Imgur.API.Endpoints.Impl;
using Imgur.API.Enums;
using Imgur.API.Models;
using Xunit;

// ReSharper disable ExceptionNotDocumented

namespace Imgur.API.Tests.Integration.Endpoints.AlbumEndpointTests
{
    public class ImgurClientTests : TestBase
    {
        public async Task AddAlbumImagesAsync_WithAlbum_Equal(IAlbum actualAlbum)
        {
            var client = new ImgurClient(Settings.ClientId);
            var endpoint = new AlbumEndpoint(client);

            var updated =
                await
                    endpoint.AddAlbumImagesAsync(actualAlbum.DeleteHash,
                        new List<string> {"KM5gQeJ", "VzbrLbO", "OkFyVOe", "Y8BbQuU"}).ConfigureAwait(false);

            Assert.True(updated);
        }

        [Fact]
        [Trait("Category", "AlbumEndpoint")]
        public async Task CreateAlbumAsync_NotNull()
        {
            var client = new ImgurClient(Settings.ClientId);
            var endpoint = new AlbumEndpoint(client);

            var album = await endpoint.CreateAlbumAsync(
                "TheTitle", "TheDescription",
                AlbumPrivacy.Hidden, AlbumLayout.Grid,
                "KM5gQeJ", new List<string> { "KM5gQeJ", "VzbrLbO"}).ConfigureAwait(false);

            Assert.NotNull(album);
            Assert.NotNull(album.Id);
            Assert.NotNull(album.DeleteHash);

            await GetAlbumAsync_WithAlbum_Equal(album).ConfigureAwait(false);
            await GetAlbumImageAsync_WithAlbum_Equal(album).ConfigureAwait(false);
            await GetAlbumImagesAsync_WithAlbum_Equal(album).ConfigureAwait(false);
            await UpdateAlbumAsync_WithAlbum_Equal(album).ConfigureAwait(false);
            await AddAlbumImagesAsync_WithAlbum_Equal(album).ConfigureAwait(false);
            await RemoveAlbumImagesAsync_WithAlbum_Equal(album).ConfigureAwait(false);
            await SetAlbumImagesAsync_WithAlbum_Equal(album).ConfigureAwait(false);
            await DeleteImageAsync_WithImage_True(album).ConfigureAwait(false);
        }

        public async Task DeleteImageAsync_WithImage_True(IAlbum actualAlbum)
        {
            var client = new ImgurClient(Settings.ClientId);
            var endpoint = new AlbumEndpoint(client);

            var deleted = await endpoint.DeleteAlbumAsync(actualAlbum.DeleteHash).ConfigureAwait(false);

            Assert.True(deleted);
        }

        public async Task GetAlbumAsync_WithAlbum_Equal(IAlbum actualAlbum)
        {
            var client = new ImgurClient(Settings.ClientId);
            var endpoint = new AlbumEndpoint(client);

            var album = await endpoint.GetAlbumAsync(actualAlbum.Id).ConfigureAwait(false);

            Assert.Equal(actualAlbum.Id, album.Id);
        }

        public async Task GetAlbumImageAsync_WithAlbum_Equal(IAlbum actualAlbum)
        {
            var client = new ImgurClient(Settings.ClientId);
            var endpoint = new AlbumEndpoint(client);

            var image = await endpoint.GetAlbumImageAsync("KM5gQeJ", actualAlbum.Id).ConfigureAwait(false);

            Assert.NotNull(image);
            Assert.Equal("KM5gQeJ", image.Id);
        }

        public async Task GetAlbumImagesAsync_WithAlbum_Equal(IAlbum actualAlbum)
        {
            var client = new ImgurClient(Settings.ClientId);
            var endpoint = new AlbumEndpoint(client);

            var albums = await endpoint.GetAlbumImagesAsync(actualAlbum.Id).ConfigureAwait(false);

            Assert.Equal(2, albums.Count());
        }

        public async Task RemoveAlbumImagesAsync_WithAlbum_Equal(IAlbum actualAlbum)
        {
            var client = new ImgurClient(Settings.ClientId);
            var endpoint = new AlbumEndpoint(client);

            var updated =
                await
                    endpoint.RemoveAlbumImagesAsync(actualAlbum.DeleteHash, new List<string> { "KM5gQeJ", "VzbrLbO"})
                        .ConfigureAwait(false);

            Assert.True(updated);
        }

        public async Task SetAlbumImagesAsync_WithAlbum_Equal(IAlbum actualAlbum)
        {
            var client = new ImgurClient(Settings.ClientId);
            var endpoint = new AlbumEndpoint(client);

            var updated =
                await
                    endpoint.SetAlbumImagesAsync(actualAlbum.DeleteHash,
                        new List<string> { "KM5gQeJ", "OkFyVOe", "Y8BbQuU"}).ConfigureAwait(false);

            Assert.True(updated);
        }

        public async Task UpdateAlbumAsync_WithAlbum_Equal(IAlbum actualAlbum)
        {
            var client = new ImgurClient(Settings.ClientId);
            var endpoint = new AlbumEndpoint(client);

            var updated = await endpoint.UpdateAlbumAsync(actualAlbum.DeleteHash, "TestTitle").ConfigureAwait(false);

            Assert.True(updated);
        }
    }
}