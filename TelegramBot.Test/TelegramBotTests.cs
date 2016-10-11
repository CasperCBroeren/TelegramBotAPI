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
            bool initOk = await bot.InitAsync();
            Assert.Equal(true, initOk);
        }

        [Fact]
        public async Task Test_WebhookSet()
        {
            var bot = new TelegramBot(TelegramToken);
            var result = await bot.SetWebHookAsync("https://github.com/kolar/telegram-poll-bot/blob/master/TelegramBot.php");
            Assert.Equal(true, result);
        }

        [Fact]
        public async Task Test_WebhookRemove()
        {
            var bot = new TelegramBot(TelegramToken);
            var result = await bot.RemoveWebHookAsync();
            Assert.Equal(true, result);
        }

        [Fact]
        public async Task Test_Longpolling()
        {
            var bot = new TelegramBot(TelegramToken);
            await bot.RunLongPollAsync(MessageReceived);

            // Assert.Equal(true, result);
        }

        public void MessageReceived(Update u)
        {
            output.WriteLine("Message: {0}", u.Message.Text);
            var bot = new TelegramBot(TelegramToken);
            var result =   bot.SendMessageAsync(new MessageToSend()
            {
                ChatID = u.Message.From.ID.ToString(),
                Text = "Mauuuuw....<b>MAH</b>",
                ParseMode = "HTML"
            });
            result.Wait();
        }
        [Fact]
        public async Task SendToUser()
        {
            var userID = "264162278";
            var bot = new TelegramBot(TelegramToken);
            var result = await bot.SendMessageAsync(new MessageToSend() {
                ChatID = userID,
                Text = "Mauuuuw....<b>MAH</b>", 
                 ParseMode = "HTML"
            });
            Assert.True(result.Ok);
        }
    }
}
