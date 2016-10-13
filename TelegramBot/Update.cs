using System.Runtime.Serialization;

namespace TelegramBot
{
    /// <summary>
    /// The update comming from the Telegram API
    /// </summary>
    [DataContract]
    public class Update
    {
        /// <summary>
        /// The id of the update which can be used in the offset in longpolling
        /// </summary>
        [DataMember(Name="update_id")]
        public int UpdateID { get; set; }

        /// <summary>
        /// Optional. New incoming message of any kind — text, photo, sticker, etc.
        /// </summary>
        [DataMember(Name="message")]
        public Message Message { get; set; }
        
        /// <summary>
        /// Optional. New version of a message that is known to the bot and was edited
        /// </summary>
        [DataMember(Name="edited_message")]
        public Message EditedMessage { get; set; }


        /// <summary>
        /// Optional. New incoming inline query
        /// </summary>
        [DataMember(Name="inline_query")]
        public InlineQuery InlineQuery { get; set; }



        /// <summary>
        /// Optional. New incoming inline query
        /// </summary>
        [DataMember(Name="chosen_inline_result")]
        public ChosenInlineResult ChosenInlineResult { get; set; }



        /// <summary>
        /// Optional. New incoming inline query
        /// </summary>
        [DataMember(Name="callback_query")]
        public CallbackQuery CallbackQuery { get; set; }
      
    }
}
