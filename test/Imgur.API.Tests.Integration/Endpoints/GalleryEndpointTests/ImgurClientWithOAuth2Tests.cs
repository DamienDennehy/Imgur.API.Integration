using System.Linq;
using System.Threading.Tasks;
using Imgur.API.Authentication.Impl;
using Imgur.API.Endpoints.Impl;
using Imgur.API.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// ReSharper disable ExceptionNotDocumented

namespace Imgur.API.Tests.Integration.Endpoints.GalleryEndpointTests
{
    [TestClass]
    public class ImgurClientTestWithOAuth2Tests : TestBase
    {
        //[TestMethod]
        //[TestCategory("GalleryEndpoint")]
        //public async Task PublishToGalleryAsync_IsTrue()
        //{
        //    var client = new ImgurClient(ClientId, ClientSecret, OAuth2Token);
        //    var endpoint = new GalleryEndpoint(client);

        //    var published = await endpoint.PublishToGalleryAsync("Rp47ldM", "API Publish Test", "2", true, false).ConfigureAwait(false);

        //    Assert.IsTrue(published);

        //    var removed = await endpoint.RemoveFromGalleryAsync("Rp47ldM").ConfigureAwait(false);

        //    Assert.IsTrue(removed);
        //}

        //[TestMethod]
        //[TestCategory("GalleryEndpoint")]
        //public async Task ReportGalleryItemAsync_IsTrue()
        //{
        //    var client = new ImgurClient(ClientId, ClientSecret, OAuth2Token);
        //    var endpoint = new GalleryEndpoint(client);

        //    var reported = await endpoint.ReportGalleryItemAsync("olQIw", ReportReason.Pornography).ConfigureAwait(false);

        //    Assert.IsTrue(reported);
        //}
    }
}