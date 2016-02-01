using System.Linq;
using System.Threading.Tasks;
using Imgur.API.Authentication.Impl;
using Imgur.API.Endpoints.Impl;
using Xunit;

// ReSharper disable ExceptionNotDocumented

namespace Imgur.API.Tests.Integration.Endpoints.AccountEndpointGalleryTests
{
    public class MashapeClientTests : TestBase
    {
        [Fact]
        [Trait("Category", "AccountEndpointGallery")]
        public async Task GetAccountGalleryFavoritesAsync_Any()
        {
            var client = new MashapeClient(Settings.ClientId, Settings.MashapeKey);
            var endpoint = new AccountEndpoint(client);

            var favourites = await endpoint.GetAccountGalleryFavoritesAsync("sarah").ConfigureAwait(false);

            Assert.True(favourites.Any());
        }

        [Fact]
        [Trait("Category", "AccountEndpointGallery")]
        public async Task GetAccountSubmissionsAsync_Any()
        {
            var client = new MashapeClient(Settings.ClientId, Settings.MashapeKey);
            var endpoint = new AccountEndpoint(client);

            var submissions = await endpoint.GetAccountSubmissionsAsync("sarah").ConfigureAwait(false);

            Assert.True(submissions.Any());
        }

        [Fact]
        [Trait("Category", "AccountEndpointGallery")]
        public async Task GetGalleryProfileAsync_AnyTrophies()
        {
            var client = new MashapeClient(Settings.ClientId, Settings.MashapeKey);
            var endpoint = new AccountEndpoint(client);

            var profile = await endpoint.GetGalleryProfileAsync("sarah").ConfigureAwait(false);

            Assert.True(profile.Trophies.Any());
        }
    }
}