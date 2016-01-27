using System;
using System.Threading.Tasks;
using Imgur.API.Authentication.Impl;
using Imgur.API.Endpoints.Impl;
using Imgur.API.Enums;
using Xunit;

// ReSharper disable ExceptionNotDocumented

namespace Imgur.API.Tests.Integration.Endpoints.AccountEndpointTests
{
    public class MashapeClientWithOAuth2Tests : TestBase
    {
        [Fact]
        [Trait("Category", "AccountEndpoint")]
        public async Task GetAccountAsync_WithDefaultUsername_Equal()
        {
            var client = new MashapeClient(Settings.ClientId, Settings.ClientSecret, Settings.MashapeKey, OAuth2Token);
            var endpoint = new AccountEndpoint(client);

            var account = await endpoint.GetAccountAsync().ConfigureAwait(false);

            Assert.True(account.Url.Equals("ImgurAPIDotNet", StringComparison.OrdinalIgnoreCase));
        }

        [Fact]
        [Trait("Category", "AccountEndpoint")]
        public async Task GetAccountAsync_WithUsername_Equal()
        {
            var client = new MashapeClient(Settings.ClientId, Settings.ClientSecret, Settings.MashapeKey, OAuth2Token);
            var endpoint = new AccountEndpoint(client);

            var account = await endpoint.GetAccountAsync("sarah").ConfigureAwait(false);

            Assert.True("sarah".Equals(account.Url, StringComparison.OrdinalIgnoreCase));
        }

        [Fact]
        [Trait("Category", "AccountEndpoint")]
        public async Task GetAccountSettingsAsync_True()
        {
            var client = new MashapeClient(Settings.ClientId, Settings.ClientSecret, Settings.MashapeKey, OAuth2Token);
            var endpoint = new AccountEndpoint(client);

            var settings = await endpoint.GetAccountSettingsAsync().ConfigureAwait(false);

            Assert.False(settings.PublicImages);
        }

        [Fact]
        [Trait("Category", "AccountEndpoint")]
        public async Task SendVerificationEmailAsync_True()
        {
            var client = new MashapeClient(Settings.ClientId, Settings.ClientSecret, Settings.MashapeKey, OAuth2Token);
            var endpoint = new AccountEndpoint(client);

            var exception =
                await
                    Record.ExceptionAsync(async () => await endpoint.SendVerificationEmailAsync().ConfigureAwait(false))
                        .ConfigureAwait(false);
            Assert.NotNull(exception);
            Assert.IsType<ImgurException>(exception);
        }

        [Fact]
        [Trait("Category", "AccountEndpoint")]
        public async Task UpdateAccountSettingsAsync_True()
        {
            var client = new MashapeClient(Settings.ClientId, Settings.ClientSecret, Settings.MashapeKey, OAuth2Token);
            var endpoint = new AccountEndpoint(client);

            var updated =
                await
                    endpoint.UpdateAccountSettingsAsync("ImgurClient_" + DateTimeOffset.UtcNow, false,
                        albumPrivacy: AlbumPrivacy.Hidden).ConfigureAwait(false);

            Assert.True(updated);
        }

        [Fact]
        [Trait("Category", "AccountEndpoint")]
        public async Task VerifyEmailAsync_True()
        {
            var client = new MashapeClient(Settings.ClientId, Settings.ClientSecret, Settings.MashapeKey, OAuth2Token);
            var endpoint = new AccountEndpoint(client);

            var verified = await endpoint.VerifyEmailAsync().ConfigureAwait(false);

            Assert.True(verified);
        }
    }
}