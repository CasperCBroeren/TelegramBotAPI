using System;
using System.Threading.Tasks;
using TelegramBot.ResponseObjects;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading;
using System.IO;
using System.Text;
using TelegramBot.RequestObjects;

namespace TelegramBot
{
    public delegate void UpdateReceived(Update update);
    /// <summary>
    /// Inspiration from https://github.com/kolar/telegram-poll-bot/blob/master/TelegramBot.php
    /// Conforms to https://core.telegram.org/bots/api
    /// </summary>
    public class TelegramBot
    {
        ///<summary>
        /// The amount of updates to receive before exit longpolling
        ///</summary>
        public int UpdatesLimit { get; set; } = 30;
        ///<summary>
        /// The timeout in seconds before timing out the longpolling
        ///</summary>
        public int UpdatesTimeout { get; set; } = 10;

        /// <summary>
        /// The updateID to start from when longpolling
        ///</summary>
        public int? UpdatesOffset { get; set; } = null;
        /// <summary>
        /// The connection timeout on the longpoll connection
        /// </summary>
        public int NetConnectionTimeout { get; set; }

        /// <summary>
        /// The delegate called when a message is received
        /// </summary>
        public UpdateReceived OnUpdateReceived { get; set; }
        /// <summary>
        /// The Telegram bot token, this can be retrieved from the BotFather bot.
        /// </summary>
        public string Token { get; set; }
        /// <summary>
        /// State indicates that the bot has been inited and the getMe request has been send and result was true
        /// </summary>
        public bool Inited { get; private set; }

        /// <summary>
        /// The url to wich we communicate, constructed in the ctor 
        /// </summary>
        public string ApiURL { get; private set; }
        /// <summary>
        /// The BotID is filled when the Init has been called and true has been received from the Telegram server
        /// </summary>
        public int BotId { get; private set; }
        /// <summary>
        /// The Bot username is filled when the Init has been called and true has been received from the Telegram server
        /// </summary>
        public string BotUsername { get; set; }

        ///<summary>
        /// The constructor which sets the token and ApiURL
        ///</summary>
        public TelegramBot(string token, TelegramBotOptions options = null)
        {
            if (options == null) options = new TelegramBotOptions();
            Token = token;
            string protoPart = (options.Port == 443) ? "https" : "http";
            string portPart = (options.Port == 443 || options.Port == 80) ? "" : ":" + options.Port;
            ApiURL = $"{protoPart}://{options.Host}{portPart}/bot{Token}";
        }


        /// <summary>
        /// The init which calls the getMe method of the Telegram api. When called multiple times and the first call was OK, the sequential calls don't call the API
        /// </summary>
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
        /// <summary>
        /// Sends a MessageToSend to a chatID or user. 
        /// </summary>
        public async Task<MessageResponse> SendMessageAsync(MessageToSend message)
        {
            await InitAsync(); 
            var result = await DoRequest<MessageResponse>("sendMessage", message);

            return result;
        }
        /// <summary>
        /// Use this method to send photos. On success, the sent Message is returned.
        /// </summary>
        public async Task<MessageResponse> SendPhotoAsync(PhotoToSend photo)
        {
            await InitAsync();
            MessageResponse result = null;
            if (photo.PhotoStream != null)
            {
                photo.Method = "POST";
                result = await DoRequest<MessageResponse>("sendPhoto", photo);
            }
            else
            {
                photo.Method = "JSON";
                result = await DoRequest<MessageResponse>("sendPhoto", photo );
            }

            return result;
        }
        /// <summary>
        /// Use this method to send audio. On success, the sent Message is returned.
        /// </summary>
        public async Task<MessageResponse> SendAudioAsync(AudioToSend audio)
        {
            await InitAsync();
            MessageResponse result = null;
            if (audio.AudioStream != null)
            {
                audio.Method = "POST";
                result = await DoRequest<MessageResponse>("sendAudio", audio);
            }
            else
            {
                audio.Method = "JSON";
                result = await DoRequest<MessageResponse>("sendAudio", audio);
            }

            return result;
        }
        /// <summary>
        /// Use this method to send voice. On success, the sent Message is returned.
        /// If you want Telegram clients to display the file as a playable voice message. For this to work, your audio must be in an .ogg file encoded with OPUS (other formats may be sent as Audio or Document). On success, the sent Message is returned. Bots can currently send voice messages of up to 50 MB in size, this limit may be changed in the future.
        /// </summary>
        public async Task<MessageResponse> SendVoiceAsync(VoiceToSend voice)
        {
            await InitAsync();
            MessageResponse result = null;
            if (voice.VoiceStream != null)
            {
                voice.Method = "POST";
                result = await DoRequest<MessageResponse>("sendVoice", voice);
            }
            else
            {
                voice.Method = "JSON";
                result = await DoRequest<MessageResponse>("sendVoice", voice);
            }

            return result;
        }
        /// <summary>
        /// Use this method to send a document. On success, the sent Message is returned.
        /// </summary>
        public async Task<MessageResponse> SendDocumentAsync(DocumentToSend document)
        {
            await InitAsync();
            var result = await DoRequest<MessageResponse>("sendDocument", new JsonToSend
            {
                Method = "JSON",
                Payload = document
            });

            return result;
        }

        /// <summary>
        /// Executes the longpolling and gives updates through the supplied delegate UpdateReceived
        /// </summary>
        public async Task RunLongPollAsync(UpdateReceived onUpdateReceived, CancellationToken token)
        {
            await InitAsync();
            await LongPoll(onUpdateReceived, token);
        }
        /// <summary>
        /// Sets the webhook to the url. The URL must start with HTTPS as required by the Telegram API
        /// </summary>
        public async Task<bool> SetWebHookAsync(string url)
        {
            if (string.IsNullOrEmpty(url) || !url.ToLower().StartsWith("https:")) throw new ArgumentException("The url should start with https");
            await InitAsync();
            var result = await DoRequest<WebHookResponse>("setWebhook", new BasicToSend
            {
                Method = "POST",
                URL = url
            });
            return result.Ok;
        }

     

        /// <summary>
        /// Removes the webhook, which basicly calls setWebhook with empty url parameter
        /// </summary>
        public async Task<bool> RemoveWebHookAsync()
        {
            await InitAsync();
            var result = await DoRequest<WebHookResponse>("setWebhook", new BasicToSend
            {
                Method = "POST",
                URL = ""
            });
            return result.Ok;
        }

        /// <summary>
        /// Use this method to get current webhook status. Requires no parameters. On success, returns a WebhookInfo object. If the bot is using getUpdates, will return an object with the url field empty.
        /// </summary>
        public async Task<WebHookInfoResponse> GetWebhookInfoAsync()
        {
            await InitAsync();
            var result = await DoRequest<WebHookInfoResponse>("getWebhookInfo", new BasicToSend { Method = "GET" });
            return result;
        }

        /// <summary>
        /// Internal Longpoll method which can be call recursively
        /// </summary>
        private async Task LongPoll(UpdateReceived onUpdateReceived, CancellationToken cancelToken)
        {

            var getUpdateTask = Task.Run(() => DoRequest<UpdateResponse>("getUpdates", new BasicToSend
            {
                Method = "POST",
                Limit = UpdatesLimit,
                Timeout = UpdatesTimeout,
                Offset = UpdatesOffset
            }), cancelToken);
            var result = await getUpdateTask;

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

            await LongPoll(onUpdateReceived, cancelToken);
        }

        /// <summary>
        /// Internal method to make the GET/POST request to the Telegram API
        /// </summary>
        private async Task<T> DoRequest<T>(string action, IToSend options) where T : new()
        {

            using (var client = new HttpClient())
            {

                var uri = new System.Uri($"{ApiURL}/{action}");
                var request = new HttpRequestMessage(HttpMethod.Get, uri);

                if (options != null && options.Method == "POST")
                {
                    request.Headers.Add("ContentType", "application/x-www-form-urlencoded");
                    request.Method = HttpMethod.Post;
                    var values = new MultipartFormDataContent();
                    if (!String.IsNullOrEmpty(options.URL)) values.Add(new StringContent(options.URL), "url");
                    if (options.Limit.HasValue) values.Add(new StringContent(options.Limit.ToString(), Encoding.UTF8), "limit");
                    if (options.Timeout.HasValue) values.Add(new StringContent(options.Timeout.ToString(), Encoding.UTF8), "timeout");
                    if (options.Offset.HasValue) values.Add(new StringContent(options.Offset.ToString(), Encoding.UTF8), "offset");

                    if (options is PhotoToSend)
                    {
                        var photoToSend = (PhotoToSend)options;
                        if (!String.IsNullOrEmpty(photoToSend.Caption)) values.Add(new StringContent(photoToSend.Caption), "caption");
                        if (!String.IsNullOrEmpty(photoToSend.ChatID)) values.Add(new StringContent(photoToSend.ChatID), "chat_id");
                        values.Add(new StringContent(photoToSend.DisableNotification ? "true" : "false"), "disable_notification");

                        if (photoToSend.ReplyMarkup !=null) values.Add(new StringContent(JsonConvert.SerializeObject(photoToSend.ReplyMarkup)), "reply_markup");
                        if (photoToSend.ReplyToMessageID.HasValue) values.Add(new StringContent(photoToSend.ReplyToMessageID.Value.ToString()), "reply_to_message_id");
                        if (photoToSend.PhotoStream != null) values.Add(new StreamContent((Stream)photoToSend.PhotoStream), "photo", photoToSend.PhotoName);
                    }
                    if (options is AudioToSend)
                    {
                        var audioToSend = (AudioToSend)options;
                        if (!String.IsNullOrEmpty(audioToSend.ChatID)) values.Add(new StringContent(audioToSend.ChatID), "chat_id");
                        if (!String.IsNullOrEmpty(audioToSend.Caption)) values.Add(new StringContent(audioToSend.Caption), "caption");
                        if ( audioToSend.Duration.HasValue) values.Add(new StringContent(audioToSend.Duration.ToString(), Encoding.UTF8), "duration");
                        if (!String.IsNullOrEmpty(audioToSend.Performer)) values.Add(new StringContent(audioToSend.Performer), "performer");
                        if (!String.IsNullOrEmpty(audioToSend.Title)) values.Add(new StringContent(audioToSend.Title), "title");
                        values.Add(new StringContent(audioToSend.DisableNotification ? "true" : "false"), "disable_notification");

                        if (audioToSend.ReplyMarkup != null) values.Add(new StringContent(JsonConvert.SerializeObject(audioToSend.ReplyMarkup)), "reply_markup");
                        if (audioToSend.ReplyToMessageID.HasValue) values.Add(new StringContent(audioToSend.ReplyToMessageID.Value.ToString()), "reply_to_message_id");
                        if (audioToSend.AudioStream != null) values.Add(new StreamContent((Stream)audioToSend.AudioStream), "audio", audioToSend.AudioName);
                    }

                    if (options is VoiceToSend)
                    {
                        var voiceToSend = (VoiceToSend)options;
                        if (!String.IsNullOrEmpty(voiceToSend.ChatID)) values.Add(new StringContent(voiceToSend.ChatID), "chat_id");
                        if (!String.IsNullOrEmpty(voiceToSend.Caption)) values.Add(new StringContent(voiceToSend.Caption), "caption");
                        if (voiceToSend.Duration.HasValue) values.Add(new StringContent(voiceToSend.Duration.ToString(), Encoding.UTF8), "duration");
                
 
                        values.Add(new StringContent(voiceToSend.DisableNotification ? "true" : "false"), "disable_notification");

                        if (voiceToSend.ReplyMarkup != null) values.Add(new StringContent(JsonConvert.SerializeObject(voiceToSend.ReplyMarkup)), "reply_markup");
                        if (voiceToSend.ReplyToMessageID.HasValue) values.Add(new StringContent(voiceToSend.ReplyToMessageID.Value.ToString()), "reply_to_message_id");
                        if (voiceToSend.VoiceStream != null) values.Add(new StreamContent((Stream)voiceToSend.VoiceStream), "voice", voiceToSend.VoiceName);
                    }
                    if (action == "getUpdates")
                    {
                        client.Timeout = TimeSpan.FromSeconds(NetConnectionTimeout + options.Limit.Value + 2);
                    }

                    request.Content = values;
                   
                }
                if (options != null && options.Method == "JSON")
                {


                    request.Method = HttpMethod.Post;
                    if (options is JsonToSend)
                    {
                        string serialized =   JsonConvert.SerializeObject(((JsonToSend)options).Payload, Formatting.None, new JsonSerializerSettings()
                        {
                            NullValueHandling = NullValueHandling.Ignore
                        });
                        request.Content = new StringContent(serialized, Encoding.UTF8, "application/json");
                    }
                    else
                    {
                        string serialized = JsonConvert.SerializeObject(options, Formatting.None, new JsonSerializerSettings()
                        {
                            NullValueHandling = NullValueHandling.Ignore
                        });
                        request.Content = new StringContent(serialized, Encoding.UTF8, "application/json");
                    }
                }

                var response = await client.SendAsync(request).ConfigureAwait(false);

                var result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                T returnObject = default(T);
                await Task.Factory.StartNew(() =>
                {
                    returnObject = JsonConvert.DeserializeObject<T>(result);
                }).ConfigureAwait(false);

                return returnObject;

            }

        }
        /// <summary>
        /// Checks on a dynamic if the property exists
        /// </summary>
        public static bool IsPropertyExist(dynamic item, string name)
        {
            return item != null && !String.IsNullOrEmpty(name) && item.GetType().GetProperty(name) != null;
        }
    }
}
