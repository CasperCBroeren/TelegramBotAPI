
using System.Runtime.Serialization;

namespace TelegramBot
{
    /// <summary>
    /// This object represents an incoming callback query from a callback button in an inline keyboard. If the button that originated the query was attached to a message sent by the bot, the field message will be present. If the button was attached to a message sent via the bot (in inline mode), /// the field inline_message_id will be present. Exactly one of the fields data or game_short_name will be present.
    /// </summary>
    [DataContract]
    public class CallbackQuery
    {
        /// <summary>
        /// Unique identifier for the query
        /// </summary>
        [DataMember(Name="id")]
        public int ID { get; set; }

        ///<summary>
        /// Sender
        ///</summary>
        [DataMember(Name="from")]
        public User From { get; set; }
        ///<summary>
        /// Optional. Message with the callback button that originated the query. Note that message content and message date will not be available if the message is too old
        ///</summary>
        [DataMember(Name="message")]
        public Message Message { get; set; }
        ///<summary>
        /// Optional. Identifier of the message sent via the bot in inline mode, that originated the query.
        ///</summary>
        [DataMember(Name="inline_message_id")]
        public string  InlineMessageID { get; set; }
        ///<summary>
        /// Identifier, uniquely corresponding to the chat to which the message with the callback button was sent. Useful for high scores in games.
        ///</summary>
        [DataMember(Name="chat_instance")]
        public string ChatInstance { get; set; }
        ///<summary>
        /// Optional. Data associated with the callback button. Be aware that a bad client can send arbitrary data in this field.
        ///</summary>
        [DataMember(Name="data")]
        public string Data { get; set; }
        ///<summary>
        /// Optional. Short name of a Game to be returned, serves as the unique identifier for the game
        ///</summary>
        [DataMember(Name="game_short_name")]
        public string GameShortName { get; set; }
    }

}