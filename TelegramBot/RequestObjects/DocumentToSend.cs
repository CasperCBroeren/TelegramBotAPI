 using System.Runtime.Serialization;


namespace TelegramBot.RequestObjects
{


    /// <summary>
    /// The Document and caption to send.
    /// For now only url's of the Document can be send
    /// </summary>
    [DataContract]
    public class DocumentToSend
    {

        /// <summary>
        ///Unique identifier for the target chat or username of the target channel (in the format @channelusername)
        /// </summary>
        [DataMember(Name="chat_id")]
        public string ChatID { get; set; }


        /// <summary>
        /// The Document to send  max 50mb This must be an url of the Document file
        /// </summary>
        [DataMember(Name="Document")]
        public string Document { get; set; }


        /// <summary>
        /// Document caption, 0-200 characters, optional
        /// </summary>
        [DataMember(Name="caption")]
        public string Caption { get; set; }

         /// <summary>
        ///Sends the message silently. iOS users will not receive a notification, Android users will receive a notification with no sound.
        /// </summary>
        [DataMember(Name="disable_notification")]
        public bool DisableNotification { get; set; }


        /// <summary>
        ///If the message is a reply, ID of the original message
        /// </summary>
        [DataMember(Name="reply_to_message_id")]
        public int ReplyToMessageID { get; set; }

        /// <summary>
        ///Additional interface options. A JSON-serialized object for an inline keyboard, custom reply keyboard, instructions to hide reply keyboard or to force a reply from the user.
        /// </summary>
        [DataMember(Name="reply_markup")]
        public IReplyMarkup  ReplyMarkup { get; set; }
    }
}
