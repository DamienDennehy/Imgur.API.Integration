using System.Linq;
using System.Threading.Tasks;
using Imgur.API.Authentication.Impl;
using Imgur.API.Endpoints.Impl;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// ReSharper disable ExceptionNotDocumented

namespace Imgur.API.Tests.Integration.Endpoints.MemeGenEndpointTests
{
    [TestClass]
    public class MashapeClientTests : TestBase
    {
        [TestMethod]
        [TestCategory("MemeGenEndpoint")]
        public async Task GetDefaultMemesAsync_Any()
        {
            var client = new MashapeClient(ClientId, ClientSecret, MashapeKey);
            var endpoint = new MemeGenEndpoint(client);

            var memes = await endpoint.GetDefaultMemesAsync().ConfigureAwait(false);

            Assert.IsTrue(memes.Any());
        }
    }
}