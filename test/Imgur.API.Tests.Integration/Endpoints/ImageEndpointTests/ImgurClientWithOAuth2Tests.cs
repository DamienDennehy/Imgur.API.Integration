using System.IO;
using System.Threading.Tasks;
using Imgur.API.Authentication.Impl;
using Imgur.API.Endpoints.Impl;
using Imgur.API.Models;
using Xunit;

// ReSharper disable ExceptionNotDocumented

namespace Imgur.API.Tests.Integration.Endpoints.ImageEndpointTests
{
    public class ImgurClientWithOAuth2Tests : TestBase
    {
        public async Task DeleteImageAsync_WithImage_True(IImage actualImage)
        {
            var client = new ImgurClient(Settings.ClientId, OAuth2Token);
            var endpoint = new ImageEndpoint(client);

            var expected = await endpoint.DeleteImageAsync(actualImage.Id).ConfigureAwait(false);

            Assert.True(expected);
        }

        public async Task FavoriteImageAsync_WithNotFavoritedImage_True(IImage actualImage)
        {
            var client = new ImgurClient(Settings.ClientId, OAuth2Token);
            var endpoint = new ImageEndpoint(client);

            var expected = await endpoint.FavoriteImageAsync(actualImage.Id).ConfigureAwait(false);

            Assert.True(expected);
        }

        public async Task GetImageAsync_WithImage_Equal(IImage actualImage)
        {
            var client = new ImgurClient(Settings.ClientId, OAuth2Token);
            var endpoint = new ImageEndpoint(client);

            var expectedImage = await endpoint.GetImageAsync(actualImage.Id).ConfigureAwait(false);

            Assert.Equal(actualImage.Id, expectedImage.Id);
            Assert.Equal(actualImage.Title, expectedImage.Title);
            Assert.Equal(actualImage.Description, expectedImage.Description);
            Assert.Equal(actualImage.DateTime, expectedImage.DateTime);
            Assert.Equal(actualImage.Type, expectedImage.Type);
            Assert.Equal(actualImage.Animated, expectedImage.Animated);
            Assert.Equal(actualImage.Width, expectedImage.Width);
            Assert.Equal(actualImage.Height, expectedImage.Height);
            Assert.Equal(actualImage.Size, expectedImage.Size);
            Assert.Equal(actualImage.Link, expectedImage.Link);
            Assert.Equal(actualImage.Gifv, expectedImage.Gifv);
            Assert.Equal(actualImage.Mp4, expectedImage.Mp4);
            Assert.Equal(actualImage.Webm, expectedImage.Webm);
            Assert.Equal(actualImage.Looping, expectedImage.Looping);
            Assert.Equal(actualImage.Favorite, expectedImage.Favorite);
            Assert.Equal(actualImage.Nsfw, expectedImage.Nsfw);
        }

        public async Task UnfavoriteImageAsync_WithFavoritedImage_False(IImage actualImage)
        {
            var client = new ImgurClient(Settings.ClientId, OAuth2Token);
            var endpoint = new ImageEndpoint(client);

            var expected = await endpoint.FavoriteImageAsync(actualImage.Id).ConfigureAwait(false);

            Assert.False(expected);
        }

        public async Task UpdateImageAsync_WithImage_Equal(IImage actualImage)
        {
            var client = new ImgurClient(Settings.ClientId, OAuth2Token);
            var endpoint = new ImageEndpoint(client);

            var expected = await endpoint.UpdateImageAsync(actualImage.Id, "Ti", "De").ConfigureAwait(false);

            Assert.True(expected);
        }

        [Fact]
        [Trait("Category", "ImageEndpoint")]
        public async Task UploadImageBinaryAsync_WithImage_Equal()
        {
            var client = new ImgurClient(Settings.ClientId, OAuth2Token);
            var endpoint = new ImageEndpoint(client);

            var file = File.ReadAllBytes("banana.gif");
            var image =
                await
                    endpoint.UploadImageBinaryAsync(file, null, "binary test title!", "binary test desc!")
                        .ConfigureAwait(false);

            Assert.False(string.IsNullOrEmpty(image.Id));
            Assert.Equal("binary test title!", image.Title);
            Assert.Equal("binary test desc!", image.Description);

            await GetImageAsync_WithImage_Equal(image).ConfigureAwait(false);
            await UpdateImageAsync_WithImage_Equal(image).ConfigureAwait(false);
            await FavoriteImageAsync_WithNotFavoritedImage_True(image).ConfigureAwait(false);
            await UnfavoriteImageAsync_WithFavoritedImage_False(image).ConfigureAwait(false);
            await DeleteImageAsync_WithImage_True(image).ConfigureAwait(false);
        }

        [Fact]
        [Trait("Category", "ImageEndpoint")]
        public async Task UploadImageStreamAsync_WithImage_Equal()
        {
            var client = new ImgurClient(Settings.ClientId, OAuth2Token);
            var endpoint = new ImageEndpoint(client);
            IImage image;

            using (var fs = new FileStream("banana.gif", FileMode.Open))
            {
                image =
                    await
                        endpoint.UploadImageStreamAsync(fs, null, "stream test title!", "stream test desc!")
                            .ConfigureAwait(false);
            }

            Assert.False(string.IsNullOrEmpty(image.Id));
            Assert.Equal("stream test title!", image.Title);
            Assert.Equal("stream test desc!", image.Description);

            await GetImageAsync_WithImage_Equal(image).ConfigureAwait(false);
            await UpdateImageAsync_WithImage_Equal(image).ConfigureAwait(false);
            await FavoriteImageAsync_WithNotFavoritedImage_True(image).ConfigureAwait(false);
            await UnfavoriteImageAsync_WithFavoritedImage_False(image).ConfigureAwait(false);
            await DeleteImageAsync_WithImage_True(image).ConfigureAwait(false);
        }

        [Fact]
        [Trait("Category", "ImageEndpoint")]
        public async Task UploadImageUrlAsync_WithImage_Equal()
        {
            var client = new ImgurClient(Settings.ClientId, OAuth2Token);
            var endpoint = new ImageEndpoint(client);

            var image =
                await
                    endpoint.UploadImageUrlAsync("http://i.imgur.com/Eg71tvs.gif", null, "url test title!",
                        "url test desc!").ConfigureAwait(false);

            Assert.False(string.IsNullOrEmpty(image.Id));
            Assert.Equal("url test title!", image.Title);
            Assert.Equal("url test desc!", image.Description);

            await GetImageAsync_WithImage_Equal(image).ConfigureAwait(false);
            await UpdateImageAsync_WithImage_Equal(image).ConfigureAwait(false);
            await FavoriteImageAsync_WithNotFavoritedImage_True(image).ConfigureAwait(false);
            await UnfavoriteImageAsync_WithFavoritedImage_False(image).ConfigureAwait(false);
            await DeleteImageAsync_WithImage_True(image).ConfigureAwait(false);
        }
    }
}