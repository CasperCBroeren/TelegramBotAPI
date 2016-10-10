using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace TelegramBot.Test
{
    public class Base
    {
        private const string TelegramToken = "x";
        private readonly ITestOutputHelper output;

        public Base(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public async Task Test_Init()
        {
            var bot = new TelegramBot(TelegramToken);
            bool initOk = await bot.Init();
            Assert.Equal(true, initOk);
        }

        [Fact]
        public async Task Test_WebhookSet()
        {
            var bot = new TelegramBot(TelegramToken);
            var result = await bot.SetWebHook("https://github.com/kolar/telegram-poll-bot/blob/master/TelegramBot.php");
            Assert.Equal(true, result);
        }

        [Fact]
        public async Task Test_WebhookRemove()
        {
            var bot = new TelegramBot(TelegramToken);
            var result = await bot.RemoveWebHook();
            Assert.Equal(true, result);
        }

        [Fact]
        public async Task Test_Longpolling()
        {
            var bot = new TelegramBot(TelegramToken);
            await bot.RunLongPoll(MessageReceived);

            // Assert.Equal(true, result);
        }

        public void MessageReceived(Update u)
        {
            output.WriteLine("Message: {0}", u.Message.Text);
        }

        public async Task SendToUser()
        {
            var userID = "x";
        }
    }
}
