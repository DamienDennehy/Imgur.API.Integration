using System.IO;
using Imgur.API.Authentication.Impl;
using Imgur.API.Endpoints.Impl;
using Imgur.API.Models;
using Newtonsoft.Json;

namespace Imgur.API.Tests.Integration
{
    public abstract class TestBase
    {
        private static IOAuth2Token _token;
        public ImgurApiSettings Settings => GetSettings();
        public IOAuth2Token OAuth2Token => GetOAuth2Token();

        private ImgurApiSettings GetSettings()
        {
            var content = File.ReadAllText("config.json");
            var settings = JsonConvert.DeserializeObject<ImgurApiSettings>(content);
            return settings;
        }

        private IOAuth2Token GetOAuth2Token()
        {
            if (_token != null)
                return _token;

            var authentication = new ImgurClient(Settings.ClientId, Settings.ClientSecret);
            var endpoint = new OAuth2Endpoint(authentication);
            _token = endpoint.GetTokenByRefreshTokenAsync(Settings.RefreshToken).Result;
            return _token;
        }
    }
}