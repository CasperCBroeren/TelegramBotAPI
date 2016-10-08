using System;
using System.Threading.Tasks;
using TelegramBot.ResponseObjects;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace TelegramBot
{
    public delegate void  UpdateReceived();
    /// <summary>
    /// Nicked from https://github.com/kolar/telegram-poll-bot/blob/master/TelegramBot.php
    /// Should relate to https://core.telegram.org/bots/api
    /// </summary>
    public class TelegramBot
    {
        public UpdateReceived OnUpdateReceived { get; set; }

        public string Token { get; set; }
        public bool Inited { get; private set; }
        public string ApiURL { get; set; }

        public int BotId { get; set; }
        public string BotUsername { get; set; }

        public TelegramBot(string token, TelegramBotOptions options = null)
        {
            if (options == null) options = new TelegramBotOptions();
            Token = token;
            string protoPart = (options.Port == 443)? "https": "http";
            string portPart = (options.Port == 443 || options.Port == 80) ? "" : ":" + options.Port;
            ApiURL = $"{protoPart}://{options.Host}{portPart}/bot{Token}";
        }


        public async Task<bool> Init()
        {
            if (Inited) return true;

            var response = await DoRequest<GetMeResponse>("getMe", null);
            if (!response.Ok)
                throw new Exception("Can't connect to server");

            BotId = response.Result.ID;
            BotUsername = response.Result.UserName;

            Inited = true;
            return true;
        }

        public async Task RunLongPoll()
        {
            await Init();
            await LongPoll();
        }

        public async Task<bool> SetWebHook(string url)
        {
            await Init();  
            var result = await DoRequest<WebHookResponse>("setWebhook",new {
                    Method = "POST", 
                    URL = url
            } ); 
            return result.Ok;
        }

        public async Task<bool> RemoveWebHook()
        {
            await Init();  
            var result = await DoRequest<WebHookResponse>("setWebhook",new { 
                    Method = "POST",
                    URL = ""
            } ); 
            return result.Ok;
        }
        
        private async Task LongPoll()
        {
            await Init(); 
             var result = await DoRequest<WebHookResponse>("getUpdates",new { 
                    Method = "POST",
                    URL = ""
            } );  
        }



        private async Task<T> DoRequest<T>(string action, dynamic options) where T : new()
        {
            // TODO
            using (var client = new HttpClient())
            {
                try {
                    var uri = new System.Uri($"{ApiURL}/{action}");
                    var request = new HttpRequestMessage(HttpMethod.Get, uri);
                    request.Headers.ExpectContinue = false;
                     
                    if (options != null && options.Method == "POST")
                    {
                        request.Method = HttpMethod.Post;
                        var values = new List<KeyValuePair<string, string>>();
                        if (options.URL !=null) values.Add(new KeyValuePair<string, string>("url", options.URL));
                            
                        request.Content = new FormUrlEncodedContent(values);

                    }
                     
                    var response = await client.SendAsync(request); 

                    var result = await response.Content.ReadAsStringAsync();
                    T returnObject = default(T);
                    await Task.Factory.StartNew ( () => {
                        returnObject =  JsonConvert.DeserializeObject<T>(result);
                    });
            
                    return returnObject;
                }
                catch(Exception exc)
                {
                    // TODO

                    return default(T);
                }
            } 
          
        }
    }
}
