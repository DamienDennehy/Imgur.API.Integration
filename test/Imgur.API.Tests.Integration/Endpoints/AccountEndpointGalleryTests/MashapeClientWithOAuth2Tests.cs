using System.Linq;
using System.Threading.Tasks;
using Imgur.API.Authentication.Impl;
using Imgur.API.Endpoints.Impl;
using Xunit;

// ReSharper disable ExceptionNotDocumented

namespace Imgur.API.Tests.Integration.Endpoints.AccountEndpointGalleryTests
{
    public class MashapeClientWithOAuth2Tests : TestBase
    {
        [Fact]
        [Trait("Category", "AccountEndpointGallery")]
        public async Task GetAccountFavoritesAsync_Any()
        {
            var client = new MashapeClient(Settings.ClientId, Settings.ClientSecret, Settings.MashapeKey, OAuth2Token);
            var endpoint = new AccountEndpoint(client);

            var submissions = await endpoint.GetAccountFavoritesAsync().ConfigureAwait(false);

            Assert.True(submissions.Any());
        }

        [Fact]
        [Trait("Category", "AccountEndpointGallery")]
        public async Task GetAccountGalleryFavoritesAsync_Any()
        {
            var client = new MashapeClient(Settings.ClientId, Settings.ClientSecret, Settings.MashapeKey, OAuth2Token);
            var endpoint = new AccountEndpoint(client);

            var favourites = await endpoint.GetAccountGalleryFavoritesAsync().ConfigureAwait(false);

            Assert.True(favourites.Any());
        }

        [Fact]
        [Trait("Category", "AccountEndpointGallery")]
        public async Task GetAccountSubmissionsAsync_Any()
        {
            var client = new MashapeClient(Settings.ClientId, Settings.ClientSecret, Settings.MashapeKey, OAuth2Token);
            var endpoint = new AccountEndpoint(client);

            var submissions = await endpoint.GetAccountSubmissionsAsync().ConfigureAwait(false);

            Assert.True(submissions.Any());
        }

        [Fact]
        [Trait("Category", "AccountEndpointGallery")]
        public async Task GetGalleryProfileAsync_NotNull()
        {
            var client = new MashapeClient(Settings.ClientId, Settings.ClientSecret, Settings.MashapeKey, OAuth2Token);
            var endpoint = new AccountEndpoint(client);

            var profile = await endpoint.GetGalleryProfileAsync().ConfigureAwait(false);

            Assert.NotNull(profile);
        }
    }
}