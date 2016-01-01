﻿using System;
using System.Threading.Tasks;
using Imgur.API.Authentication.Impl;
using Imgur.API.Endpoints.Impl;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// ReSharper disable ExceptionNotDocumented

namespace Imgur.API.Tests.Integration.Endpoints.AccountEndpointTests
{
    [TestClass]
    public class MashapeClientTests : TestBase
    {
        [TestMethod]
        [TestCategory("AccountEndpoint")]
        public async Task GetAccountAsync_WithUsername_AreEqual()
        {
            var client = new MashapeClient(ClientId, ClientSecret, MashapeKey);
            var endpoint = new AccountEndpoint(client);

            var account = await endpoint.GetAccountAsync("sarah").ConfigureAwait(false);

            Assert.IsTrue("sarah".Equals(account.Url, StringComparison.OrdinalIgnoreCase));
        }
    }
}