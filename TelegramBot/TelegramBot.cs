using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using TelegramBot.ResponseObjects;

namespace TelegramBot
{
    /// <summary>
    /// Nicked from https://github.com/kolar/telegram-poll-bot/blob/master/TelegramBot.php
    /// Should relate to https://core.telegram.org/bots/api
    /// </summary>
    public class TelegramBot
    {


        public string Token { get; set; }
        public bool Inited { get; private set; }
        public string ApiURL { get; set; }

        public int BotId { get; set; }
        public string BotUsername { get; set; }

        public TelegramBot(string token, TelegramBotOptions options)
        {
            Token = token;
            string protoPart = (options.Port == 443)? "https": "http";
            string portPart = (options.Port == 433 || options.Port == 80) ? "" : ":" + options.Port;
            ApiURL = $"{protoPart}://{options.Host}{portPart}/bot/{Token}";
        }


        public bool Init()
        {
            if (Inited) return true;

            var response = DoRequest<GetMeResponse>("getMe");
            if (!response.Ok)
                throw new Exception("Can't connect to server");

            BotId = response.Result.ID;
            BotUsername = response.Result.UserName;

            Inited = true;
            return true;
        }

        private T DoRequest<T>(string action) where T : new()
        {
            // TODO
            return new T();
        }
    }
}
