using PomBot.Brain;
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
    public class PomBot : TelegramBot.TelegramBot
    {
        Memory memory = null;


        public CancellationTokenSource CancellationTokenSource = new CancellationTokenSource();
        public PomBot(string token, TelegramBotOptions options = null) : base(token, options)
        {
            var lexings = new List<Lexing>();
            lexings.Add(new Brain.Lexing("greet", "hi", "hello", "good day", "hoi"));
            lexings.Add(new Brain.Lexing("doing", "how are you", "sup", "doing?", "hoe is het", "hoe gaat het", "hoe gaat ie"));
            lexings.Add(new Brain.Lexing("eat", "hugry", "food", "eat", "eten", "honger", "trek"));
            memory = new Memory(lexings);

        }

        public async Task Start()
        {

            await this.RunLongPollAsync(MessageReceived, CancellationTokenSource.Token);
        }

        public void MessageReceived(Update u)
        {
            // Check if present
            if (!memory.ContainsMeme(u.Message.From.ID.ToString()))
            {
                Meme mBase = new Brain.Meme() { Class = "user", Subject = u.Message.From.ID.ToString() };
                Meme mName = new Brain.Meme() { Class = "name", Subject = u.Message.From.FirstName };
                mBase.Relations.Add(mName.Subject, mName);
                memory.InsertMeme(mBase);
                return;
            }
            Meme personBase = memory.GetMeme(u.Message.From.ID.ToString());
            var textMeaning = memory.AnalyseSentence(u.Message.Text);

            Task result = null;
            if (textMeaning.Contains("greet"))
            {

                result = this.SendMessageAsync(new MessageToSend()
                {
                    ChatID = u.Message.From.ID.ToString(),
                    Text = "Mauw..." + u.Message.From.FirstName,
                    ParseMode = "HTML"
                });
            }
            else if (textMeaning.Contains("doing"))
            {
                if (!personBase.Relations.ContainsKey("chill"))
                {
                    var stream = File.OpenRead("chillinabox.jpg");
                    result = SendPhotoAsync(new PhotoToSend()
                    {
                        ChatID = u.Message.From.ID.ToString(),
                        PhotoStream = stream,
                        PhotoName = "chillinabox.jpg",
                        Caption = "Not much chilling in a box"
                    });
                    personBase.Relations.Add("chill", new Meme() { Subject = "chill" });
                }
                else
                {
                    result = RandomAnswer(u);

                }

            }
            else if (textMeaning.Contains("eat"))
            {
               
                  if (!personBase.Relations.ContainsKey("fridge"))
                {

                    var stream = File.OpenRead("kingofthefridge.jpg");
                    result = SendPhotoAsync(new PhotoToSend()
                    {
                        ChatID = u.Message.From.ID.ToString(),
                        PhotoStream = stream,
                        PhotoName = "kingofthefridge.jpg",
                        Caption = "Whoe ha! all ready on it.. the fridge"
                    });

                    personBase.Relations.Add("fridge", new Meme() { Subject = "fridge" });
                }
                else if (!personBase.Relations.ContainsKey("otoro"))
                {
                    result = this.SendMessageAsync(new MessageToSend()
                    {
                        ChatID = u.Message.From.ID.ToString(),
                        Text = "Aw yessss... o toro )><(((('> plz",
                        ParseMode = "HTML"
                    });
                    personBase.Relations.Add("otoro", new Meme() { Subject = "otoro" });
                }
                else
                {
                    result = this.SendMessageAsync(new MessageToSend()
                    {
                        ChatID = u.Message.From.ID.ToString(),
                        Text = "NOM nom NOM nom NOM nom NOM nom",
                        ParseMode = "HTML"
                    });
                }

            }
            else
            {
                result = RandomAnswer(u);
            }
            result.Wait();
        }

        private Task RandomAnswer(Update u)
        {
            Task result = null;
            var random = new Random(System.Environment.TickCount);
            var pos = random.Next(0, 8);

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
                    Text = "MAUW mauw mauw mauw mauw",
                    ParseMode = "HTML"
                });
            }

            if (pos == 3)
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

            if (pos == 4)
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



            if (pos == 6)
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

            if (pos == 7)
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

            return result;
        }
    }
}
