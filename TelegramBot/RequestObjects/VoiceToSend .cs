using System.IO;
using System.Runtime.Serialization;


namespace TelegramBot.RequestObjects
{


    /// <summary>
    /// The voice and caption to send.
    /// For now only url's of the voice can be send
    /// </summary>
    [DataContract]
    public class VoiceToSend: IToSend
    {

        /// <summary>
        ///Unique identifier for the target chat or username of the target channel (in the format @channelusername)
        /// </summary>
        [DataMember(Name="chat_id")]
        public string ChatID { get; set; }


        /// <summary>
        /// The voice to send in mp3 and max 50mb This must be an url of the voice file
        /// </summary>
        [DataMember(Name="voice")]
        public string voice { get; set; }


        /// <summary>
        /// voice caption, 0-200 characters, optional
        /// </summary>
        [DataMember(Name="caption")]
        public string Caption { get; set; }

        /// <summary>
        /// Duration of the voice in seconds, optional
        /// </summary>
        [DataMember(Name="duration")]
        public int? Duration { get; set; }
  

        /// <summary>
        ///Sends the message silently. iOS users will not receive a notification, Android users will receive a notification with no sound.
        /// </summary>
        [DataMember(Name="disable_notification")]
        public bool DisableNotification { get; set; }


        /// <summary>
        ///If the message is a reply, ID of the original message
        /// </summary>
        [DataMember(Name="reply_to_message_id")]
        public int? ReplyToMessageID { get; set; }

        /// <summary>
        ///Additional interface options. A JSON-serialized object for an inline keyboard, custom reply keyboard, instructions to hide reply keyboard or to force a reply from the user.
        /// </summary>
        [DataMember(Name="reply_markup")]
        public IReplyMarkup  ReplyMarkup { get; set; }
 
        /// <summary>
        /// This allows you to send a voice as a stream instead of a url
        /// </summary>
        [IgnoreDataMember()]
        public Stream VoiceStream { get; set; }
        /// <summary>
        /// This allows you to send the file name of the stream
        /// </summary>
        [IgnoreDataMember()]
        public string VoiceName { get; set; }

        public string Method { get; set; }

        public string URL { get; set; }

        public int? Limit { get; set; }
        public int? Offset { get; set; }

        public int? Timeout { get; set; }
    }
}
