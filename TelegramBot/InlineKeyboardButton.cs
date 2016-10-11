using System.Runtime.Serialization;    

namespace TelegramBot
{
    /// <summary>
    /// This object represents one button of an inline keyboard. You must use exactly one of the optional fields.
    /// </summary>
    [DataContract()]
    public class InlineKeyboardButton
    {
        /// <summary>
        /// Label text on the button
        /// </summary>
        [DataMember(Name = "name")]
        public string Text { get; set; }

        /// <summary>
        /// Optional. HTTP url to be opened when button is pressed
        /// </summary>
        [DataMember(Name = "url")]
        public string Url { get; set; }
        /// <summary>
        /// Optional. Data to be sent in a callback query to the bot when button is pressed, 1-64 bytes
        /// </summary>
        [DataMember(Name = "callback_data")]
        public string CallbackData { get; set; }

        /// <summary>
        /// Optional. If set, pressing the button will prompt the user to select one of their chats, open that chat and insert the bot‘s username and the specified inline query in the input field. Can be empty, in which case just the bot’s username will be inserted.
        /// Note: This offers an easy way for users to start using your bot in inline mode when they are currently in a private chat with it.Especially useful when combined with switch_pm… actions – in this case the user will be automatically returned to the chat they switched from, skipping the chat selection screen.
        /// </summary>
        [DataMember(Name = "switch_inline_query")]
        public string SwitchInlineQuery { get; set; }

        /// <summary>
        /// Optional. If set, pressing the button will insert the bot‘s username and the specified inline query in the current chat's input field. Can be empty, in which case only the bot’s username will be inserted.
        //  This offers a quick way for the user to open your bot in inline mode in the same chat – good for selecting something from multiple options.
        /// </summary>
        [DataMember(Name = "switch_inline_query_current_chat")]
        public string SwitchInlineQueryCurrentChat { get; set; }

        [DataMember(Name = "callback_game")]
        public CallbackGame CallbackGame { get; set; }
    }
}
