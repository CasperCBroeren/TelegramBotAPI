using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TelegramBot;
using TelegramBot.RequestObjects;

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
            Task result = null;
            if (u.Message.Text.ToLower().Contains("whats up") || u.Message.Text.ToLower().Contains("doing?") || u.Message.Text.ToLower().Contains("sup?"))
            {

                var stream = File.OpenRead("chillinabox.jpg"); 
                result = SendPhotoAsync(new PhotoToSend()
                {
                    ChatID = u.Message.From.ID.ToString(),
                    PhotoStream = stream,
                    PhotoName = "chillinabox.jpg",
                    Caption = "Not much chilling in a box"
                });
            }
            else
            {
                var random = new Random(System.Environment.TickCount);
                var pos = random.Next(0, 10);

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
                        Text = "Food!",
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

                    var stream = File.OpenRead("pomjong.jpg"); 
                    result = SendPhotoAsync(new PhotoToSend()
                    {
                        ChatID = u.Message.From.ID.ToString(),
                        PhotoStream = stream,
                        PhotoName = "pomjong.jpg",
                        Caption = "Baby picture"
                    });
                }
                
                if (pos == 6)
                {

                    var stream = File.OpenRead("backofmybox.jpg"); 
                    result = SendPhotoAsync(new PhotoToSend()
                    {
                        ChatID = u.Message.From.ID.ToString(),
                        PhotoStream = stream,
                        PhotoName = "backofmybox.jpg",
                        Caption = "BACK OF! THIS IS MY BOX.. I will use laser eyes"
                    });
                }

                if (pos == 7)
                {

                    var stream = File.OpenRead("kingofthefridge.jpg"); 
                    result = SendPhotoAsync(new PhotoToSend()
                    {
                        ChatID = u.Message.From.ID.ToString(),
                        PhotoStream = stream,
                        PhotoName = "kingofthefridge.jpg",
                        Caption = "Whoe ha! king of the fridge"
                    });
                }

                if (pos == 8)
                {

                    var stream = File.OpenRead("mauw.ogg"); 
                    result = SendVoiceAsync(new VoiceToSend()
                    {
                        ChatID = u.Message.From.ID.ToString(),
                        VoiceStream = stream,
                        VoiceName = "mauw.ogg",
                        Caption = "What does this button do?"
                    });
                }

                if (pos == 9)
                {

                    var stream = File.OpenRead("printerinspection.jpg");
                    result = SendPhotoAsync(new PhotoToSend()
                    {
                        ChatID = u.Message.From.ID.ToString(),
                        PhotoStream = stream,
                        PhotoName = "printerinspection.jpg",
                        Caption = "Is this my document printing?"
                    });
                }
            }            
            result.Wait();
        }
    }
}
