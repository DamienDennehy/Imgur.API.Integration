using System;
using System.Linq;
using System.Threading.Tasks;
using Imgur.API.Authentication.Impl;
using Imgur.API.Endpoints.Impl;
using Xunit;

// ReSharper disable ExceptionNotDocumented

namespace Imgur.API.Tests.Integration.Endpoints.ConversationEndpointTests
{
    public class MashapeClientWithOAuth2Tests : TestBase
    {
        [Fact]
        [Trait("Category", "ConversationEndpoint")]
        public async Task CreateConversationAsyncAndDeleteConversationAsync_True()
        {
            var client = new MashapeClient("123", "1234", Settings.MashapeKey, OAuth2Token);
            var endpoint = new ConversationEndpoint(client);
            string message = $"{DateTime.UtcNow}";
            var created = await endpoint.CreateConversationAsync("imgurapidotnet", message).ConfigureAwait(false);

            Assert.True(created);

            var conversations = await endpoint.GetConversationsAsync().ConfigureAwait(false);

            foreach (var conversation in conversations)
            {
                var conversationWithMessages =
                    await endpoint.GetConversationAsync(conversation.Id.ToString()).ConfigureAwait(false);

                Assert.Equal(message, conversationWithMessages.Messages.First().Body);

                var deleted = await endpoint.DeleteConversationAsync(conversation.Id.ToString()).ConfigureAwait(false);

                Assert.True(deleted);
            }
        }

        //Running the BlockSender method may cause the account to be banned?
        //[Fact]
        //[Trait("Category", "ConversationEndpoint")]
        //public async Task BlockSenderAsync_True()
        //{
        //    var client = new MashapeClient("123", "1234", MashapeKey, OAuth2Token);
        //    var endpoint = new ConversationEndpoint(client);
        //    var blocked = await endpoint.BlockSenderAsync("imgurapidotnet");

        //    Assert.True(blocked);
        //}

        //Running the ReportSender method may cause the account to be banned?
        //[Fact]
        //[Trait("Category", "ConversationEndpoint")]
        //public async Task ReportSenderAsync_True()
        //{
        //    var client = new MashapeClient("123", "1234", MashapeKey, OAuth2Token);
        //    var endpoint = new ConversationEndpoint(client);
        //    var reported = await endpoint.ReportSenderAsync("imgurapidotnet");

        //    Assert.True(reported);
        //}
    }
}