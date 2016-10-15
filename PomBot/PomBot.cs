using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TelegramBot;

namespace PomBot
{
    public class PomBot: TelegramBot.TelegramBot
    {
       public CancellationTokenSource CancellationTokenSource = new CancellationTokenSource();
        public PomBot(string token, TelegramBotOptions options = null) : base(token, options)
        {
        }

        public async Task Start()
        {
           
           await this.RunLongPollAsync(MessageReceived, CancellationTokenSource.Token);
        }

        public void MessageReceived(Update u)
        {
            var random = new Random(System.Environment.TickCount);
            var pos = random.Next(0, 6);
            Task result = null;
            if (pos == 0)
            {
                result = this.SendMessageAsync(new MessageToSend()
                {
                    ChatID = u.Message.From.ID.ToString(),
                    Text = "Mauuuuw....<b>MAH</b>",
                    ParseMode = "HTML"
                });
            }
            if (pos == 1)
            {
                result = this.SendMessageAsync(new MessageToSend()
                {
                    ChatID = u.Message.From.ID.ToString(),
                    Text = "ETEN!",
                    ParseMode = "HTML"
                });
            }
            if (pos == 2)
            {
                result = this.SendMessageAsync(new MessageToSend()
                {
                    ChatID = u.Message.From.ID.ToString(),
                    Text = "prrrrrrrrr..." + u.Message.From.FirstName,
                    ParseMode = "HTML"
                });
            }
            if (pos == 3)
            {
                result = this.SendMessageAsync(new MessageToSend()
                {
                    ChatID = u.Message.From.ID.ToString(),
                    Text = "MAUW mauw mauw mauw mauw",
                    ParseMode = "HTML"
                });
            }
            if (pos == 4)
            {
                result = this.SendMessageAsync(new MessageToSend()
                {
                    ChatID = u.Message.From.ID.ToString(),
                    Text = @" 
              a          a
             aaa        aaa
            aaaaaaaaaaaaaaaa
           aaaaaaaaaaaaaaaaaa
          aaaaafaaaaaaafaaaaaa
          aaaaaaaaaaaaaaaaaaaa
           aaaaaaaaaaaaaaaaaa
            aaaaaaa  aaaaaaa
             aaaaaaaaaaaaaa
  a         aaaaaaaaaaaaaaaa
 aaa       aaaaaaaaaaaaaaaaaa
 aaa      aaaaaaaaaaaaaaaaaaaa
 aaa     aaaaaaaaaaaaaaaaaaaaaa
 aaa    aaaaaaaaaaaaaaaaaaaaaaaa
  aaa   aaaaaaaaaaaaaaaaaaaaaaaa
  aaa   aaaaaaaaaaaaaaaaaaaaaaaa
  aaa    aaaaaaaaaaaaaaaaaaaaaa
   aaa    aaaaaaaaaaaaaaaaaaaa
    aaaaaaaaaaaaaaaaaaaaaaaaaa
     aaaaaaaaaaaaaaaaaaaaaaaaa",
                    ParseMode = "HTML"
                });
            }
            if (pos == 5)
            {

                string img = "https://blackcatsrule.files.wordpress.com/2014/10/cute-black-cat-detts6f6.jpg";
                
                result = this.SendPhotoAsync(new PhotoToSend()
                {
                    ChatID = u.Message.From.ID.ToString(),
                    Photo = img,
                    Caption = "Fake"
                });
            }
            result.Wait();
        }
    }
}
