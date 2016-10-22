using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using TelegramBot.RequestObjects;
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

        [Fact]
        public async Task SendPictureStreamed()
        {
            var stream = File.OpenRead("pomjong.jpg");
            var userID = "264162278";
            var bot = new TelegramBot(TelegramToken);
            var result = await bot.SendPhotoAsync(new PhotoToSend()
            {
                ChatID = userID,
                PhotoStream = stream,
                PhotoName = "pomjong.jpg",
                Caption = "Baby picture"
            });
            Assert.True(result.Ok);
        }

        [Fact]
        public async Task SendAudio()
        {
            var stream = File.OpenRead("bleach.mp3");
            var userID = "264162278";
            var bot = new TelegramBot(TelegramToken);
            var result = await bot.SendAudioAsync(new AudioToSend()
            {
                ChatID = userID,
                AudioStream = stream,
                AudioName = "bleach.mp3",
                Title = "Puring of bleach Ucross Wyoming",
                Performer = "Bleach as recorded by Christopher DeLaurenti",
                Duration = 180,
                Caption = "Puring of bleach Ucross Wyoming"
            });
            Assert.True(result.Ok);
        }

        [Fact]
        public async Task SendAudioUrl()
        {
             
            var userID = "264162278";
            var bot = new TelegramBot(TelegramToken);
            var result = await bot.SendAudioAsync(new AudioToSend()
            {
                ChatID = userID,
                Audio = "http://ronsen.org/purrfectsounds/purrs/bleach.mp3",
                Title = "Puring of bleach Ucross Wyoming",
                Performer = "Bleach as recorded by Christopher DeLaurenti",
                Duration = 180,
                Caption = "Puring of bleach Ucross Wyoming"
            });
            Assert.True(result.Ok);
        }

        [Fact]
        public async Task SendVoice()
        {
            var stream = File.OpenRead("catMauw.ogg");
            var userID = "264162278";
            var bot = new TelegramBot(TelegramToken);
            var result = await bot.SendVoiceAsync(new VoiceToSend()
            {
                ChatID = userID,
                VoiceStream = stream,
                VoiceName = "catMauw.ogg", 
                Duration = 130,
                Caption = "Mauw do you speak it?"
            });
            Assert.True(result.Ok);
        }

    }
}
