using System;
using System.Threading.Tasks;
using TelegramBot.ResponseObjects;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading;
using System.IO;
using System.Text;

namespace TelegramBot
{
    public delegate void UpdateReceived(Update update);
    /// <summary>
    /// Inspiration from https://github.com/kolar/telegram-poll-bot/blob/master/TelegramBot.php
    /// Confirms to https://core.telegram.org/bots/api
    /// </summary>
    public class TelegramBot
    {
        public int UpdatesLimit { get; set; } = 30;
        public int UpdatesTimeout { get; set; } = 10;
        public int? UpdatesOffset { get; set; } = null;
        public int NetConnectionTimeout { get; set; }
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
            string protoPart = (options.Port == 443) ? "https" : "http";
            string portPart = (options.Port == 443 || options.Port == 80) ? "" : ":" + options.Port;
            ApiURL = $"{protoPart}://{options.Host}{portPart}/bot{Token}";
        }


        public async Task<bool> InitAsync()
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

        public async Task<MessageResponse> SendMessageAsync(MessageToSend message)
        {
            await InitAsync();
            var result = await DoRequest<MessageResponse>("sendMessage", new
            {
                Method = "JSON",
                Payload = message
            });

            return result;
        }

        public async Task RunLongPollAsync(UpdateReceived onUpdateReceived)
        {
            await InitAsync();
            await LongPoll(onUpdateReceived);
        }

        public async Task<bool> SetWebHookAsync(string url)
        {
            await InitAsync();
            var result = await DoRequest<WebHookResponse>("setWebhook", new
            {
                Method = "POST",
                URL = url
            });
            return result.Ok;
        }

        public async Task<bool> RemoveWebHookAsync()
        {
            await InitAsync();
            var result = await DoRequest<WebHookResponse>("setWebhook", new
            {
                Method = "POST",
                URL = ""
            });
            return result.Ok;
        }

        private async Task LongPoll(UpdateReceived onUpdateReceived)
        {

            var result = await DoRequest<UpdateResponse>("getUpdates", new
            {
                Method = "POST",
                Limit = UpdatesLimit,
                Timeout = UpdatesTimeout,
                Offset = UpdatesOffset
            });
            if (result.Ok)
            {
                if (result.Result != null)
                {
                    foreach (var update in result.Result)
                    {
                        UpdatesOffset = update.UpdateID + 1;
                        if (onUpdateReceived != null)
                            onUpdateReceived.Invoke(update);
                    }
                }

            }
            await LongPoll(onUpdateReceived);
        }



        private async Task<T> DoRequest<T>(string action, dynamic options) where T : new()
        {

            using (var client = new HttpClient())
            {
                try
                {
                    var uri = new System.Uri($"{ApiURL}/{action}");
                    var request = new HttpRequestMessage(HttpMethod.Get, uri); 

                    if (options != null && options.Method == "POST")
                    {
                        request.Headers.Add("ContentType", "application/x-www-form-urlencoded");
                        request.Method = HttpMethod.Post;
                        var values = new List<KeyValuePair<string, string>>();
                        if (IsPropertyExist(options, "URL")) values.Add(new KeyValuePair<string, string>("url", options.URL));
                        if (IsPropertyExist(options, "Limit")) values.Add(new KeyValuePair<string, string>("limit", options.Limit.ToString()));
                        if (IsPropertyExist(options, "Timeout")) values.Add(new KeyValuePair<string, string>("timeout", options.Timeout.ToString()));
                        if (IsPropertyExist(options, "Offset") && options.Offset != null) values.Add(new KeyValuePair<string, string>("offset", options.Offset.ToString()));
                        if (action == "getUpdates")
                        {
                            client.Timeout = TimeSpan.FromSeconds(NetConnectionTimeout + options.Limit + 2);
                        }

                        request.Content = new FormUrlEncodedContent(values);

                    }
                    if (options != null && options.Method == "JSON")
                    {

                     
                        request.Method = HttpMethod.Post;
                        if (IsPropertyExist(options, "Payload"))
                        {
                            string serialized = await JsonConvert.SerializeObjectAsync(options.Payload, Formatting.None, new JsonSerializerSettings()
                            {
                                NullValueHandling = NullValueHandling.Ignore
                            });
                            request.Content = new StringContent(serialized, Encoding.UTF8, "application/json"); 
                        }
                    }

                    var response = await client.SendAsync(request);

                    var result = await response.Content.ReadAsStringAsync();
                    T returnObject = default(T);
                    await Task.Factory.StartNew(() =>
                    {
                        returnObject = JsonConvert.DeserializeObject<T>(result);
                    });

                    return returnObject;
                }
                catch (Exception exc)
                {
                    // TODO

                    return default(T);
                }
            }

        }
        public static bool IsPropertyExist(dynamic item, string name)
        {
            return item.GetType().GetProperty(name) != null;
        }
    }
}
