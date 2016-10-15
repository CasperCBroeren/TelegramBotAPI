using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace TelegramBot.Test
{
    public class Base
    {
        CancellationTokenSource source = new CancellationTokenSource();
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
            await bot.RunLongPollAsync(MessageReceived, source.Token);

            Assert.True(true);
        }

        public void MessageReceived(Update u)
        {
            output.WriteLine("Message: {0}", u.Message.Text);
            var bot = new TelegramBot(TelegramToken);
            var random = new Random(System.Environment.TickCount);
            int option = random.Next(0, 3);
            Task result = null;
            if (option == 0)
            {
                result = bot.SendMessageAsync(new MessageToSend()
                {
                    ChatID = u.Message.From.ID.ToString(),
                    Text = "Mauuuuw....<b>MAH</b>",
                    ParseMode = "HTML"
                });
            }
            if (option == 1)
            {
                var name = u.Message.From.FirstName != null ? u.Message.From.FirstName : u.Message.From.Username;
                result = bot.SendMessageAsync(new MessageToSend()
                {
                    ChatID = u.Message.From.ID.ToString(),
                    Text = $"<i>PRRRRRrrrrr...{name}</i>",
                    ParseMode = "HTML"
                });
            }
            if (option == 2)
            {
                result = bot.SendMessageAsync(new MessageToSend()
                {
                    ChatID = u.Message.From.ID.ToString(),
                    Text = $"Mauw mauw mauw mauw, Mauw mauw mauw mauw,Mauw mauw mauw mauw,Mauw mauw mauw mauw",
                    ParseMode = "HTML"
                });
            }
            if (option == 3)
            {
                result = bot.SendMessageAsync(new MessageToSend()
                {
                    ChatID = u.Message.From.ID.ToString(),
                    Text = $"zzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzz",
                    ParseMode = "HTML"
                });
            }
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
        [Fact]
        public async Task SendPicture()
        {
            string img = "https://blackcatsrule.files.wordpress.com/2014/10/cute-black-cat-detts6f6.jpg";
            var userID = "264162278";
            var bot = new TelegramBot(TelegramToken);
            var result = await bot.SendPhotoAsync(new PhotoToSend()
            {
                ChatID = userID,
                Photo = img,
                Caption = "Fake"
            });
            Assert.True(result.Ok);
        }
    }
}
