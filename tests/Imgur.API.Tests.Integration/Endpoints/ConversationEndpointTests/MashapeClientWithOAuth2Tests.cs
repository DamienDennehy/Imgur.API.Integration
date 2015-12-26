using System;
using System.Linq;
using System.Threading.Tasks;
using Imgur.API.Authentication.Impl;
using Imgur.API.Endpoints.Impl;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Imgur.API.Tests.Integration.Endpoints.ConversationEndpointTests
{
    [TestClass]
    public class MashapeClientWithOAuth2Tests: TestBase
    {
        [TestMethod]
        [TestCategory("ConversationEndpoint")]
        public async Task CreateConversationAsyncAndDeleteConversationAsync_IsTrue()
        {
            var client = new MashapeClient("123", "1234", MashapeKey, OAuth2Token);
            var endpoint = new ConversationEndpoint(client);
            string message = DateTime.UtcNow.ToString();
            var created = await endpoint.CreateConversationAsync("imgurapidotnet", message);

            Assert.IsTrue(created);

            var conversations = await endpoint.GetConversationsAsync();
            
            foreach (var conversation in conversations)
            {
                var conversationWithMessages = await endpoint.GetConversationAsync(conversation.Id.ToString());

                Assert.AreEqual(message, conversationWithMessages.Messages.First().Body);

                var deleted = await endpoint.DeleteConversationAsync(conversation.Id.ToString());

                Assert.IsTrue(deleted);
            }
        }

        //Running the BlockSender method may cause the account to be banned?
        //[TestMethod]
        //[TestCategory("ConversationEndpoint")]
        //public async Task BlockSenderAsync_IsTrue()
        //{
        //    var client = new MashapeClient("123", "1234", MashapeKey, OAuth2Token);
        //    var endpoint = new ConversationEndpoint(client);
        //    var blocked = await endpoint.BlockSenderAsync("imgurapidotnet");

        //    Assert.IsTrue(blocked);
        //}

        //Running the ReportSender method may cause the account to be banned?
        //[TestMethod]
        //[TestCategory("ConversationEndpoint")]
        //public async Task ReportSenderAsync_IsTrue()
        //{
        //    var client = new MashapeClient("123", "1234", MashapeKey, OAuth2Token);
        //    var endpoint = new ConversationEndpoint(client);
        //    var reported = await endpoint.ReportSenderAsync("imgurapidotnet");

        //    Assert.IsTrue(reported);
        //}
    }
}
