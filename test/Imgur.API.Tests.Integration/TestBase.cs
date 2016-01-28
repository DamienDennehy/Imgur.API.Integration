using System.IO;
using Imgur.API.Models;
using Imgur.API.Models.Impl;
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

            _token = new OAuth2Token(Settings.AccessToken, Settings.RefreshToken, "bearer", "24562464", "imgurapidotnet",
                2629746);
            return _token;
        }
    }
}