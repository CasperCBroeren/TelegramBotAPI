using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace TelegramBot.RequestObjects
{
    [DataContract]
    public class MessageToSend
    {
        /// <summary>
        /// Unique identifier for the target chat or username of the target channel (in the format @channelusername)
        /// </summary>
        [DataMember(Name ="chat_id")]
        public string ChatID { get; set; }
        /// <summary>
        /// Text of the message to be sent
        /// </summary>
        [DataMember(Name ="text")]
        public string Text { get; set; }

        /// <summary>
        /// Send Markdown or HTML, if you want Telegram apps to show bold, italic, fixed-width text or inline URLs in your bot's message.
        /// </summary>
        [DataMember(Name ="parse_mode")]
        public string ParseMode { get; set; }

        /// <summary>
        /// Disables link previews for links in this message
        /// </summary>
        [DataMember(Name = "disable_web_page_preview")]
        public bool? DisableWebPagePreview { get; set; }

        /// <summary>
        /// Sends the message silently. iOS users will not receive a notification, Android users will receive a notification with no sound.
        /// </summary>
        [DataMember(Name = "disable_notification")]
        public bool? DisableNotification { get; set; }

        /// <summary>
        /// If the message is a reply, ID of the original message
        /// </summary>
        [DataMember(Name = "reply_to_message_id")]
        public int? ReplyToMessageID { get; set; }

        /// <summary>
        /// Additional interface options. A JSON-serialized object for an inline keyboard, custom reply keyboard, instructions to hide reply keyboard or to force a reply from the user.
        /// </summary>
        [DataMember(Name = "reply_markup")]
        public IReplyMarkup ReplyMarkup { get; set; }
    }

    /// <summary>
    /// This object represents an inline keyboard that appears right next to the message it belongs to.
    /// Note:  This will only work in Telegram versions released after 9 April, 2016. Older clients will display unsupported message.
    /// </summary>
    [DataContract()]
    public class InlineKeyboardMarkup: IReplyMarkup
    {
        /// <summary>
        /// Array of button rows, each represented by an Array of InlineKeyboardButton objects
        /// </summary>
        [DataMember(Name = "inline_keyboard")]
        public InlineKeyboardButton[][] InlineKeyboard { get; set; }
    }

    /// <summary>
    /// This object represents a custom keyboard with reply options (see Introduction to bots for details and examples).
    /// </summary>
    [DataContract()]
    public class ReplyKeyboardMarkup : IReplyMarkup
    {
        /// <summary>
        /// Array of button rows, each represented by an Array of KeyboardButton objects
        /// </summary>
        [DataMember(Name = "keyboard")]
        public KeyboardButton[][] Keyboard { get; set; }

        /// <summary>
        /// 	Optional. Requests clients to resize the keyboard vertically for optimal fit (e.g., make the keyboard smaller if there are just two rows of buttons). Defaults to false, in which case the custom keyboard is always of the same height as the app's standard keyboard.
        /// </summary>
        [DataMember(Name = "resize_keyboard")]
        public bool ResizeKeyboard { get; set; }

        /// <summary>
        /// Optional. Requests clients to hide the keyboard as soon as it's been used. The keyboard will still be available, but clients will automatically display the usual letter-keyboard in the chat – the user can press a special button in the input field to see the custom keyboard again. Defaults to false.
        /// </summary>
        [DataMember(Name = "one_time_keyboard")]
        public bool OneTimeKeyboard { get; set; }

        /// <summary>
        /// Optional. Use this parameter if you want to show the keyboard to specific users only. Targets: 1) users that are @mentioned in the text of the Message object; 2) if the bot's message is a reply (has reply_to_message_id), sender of the original message.
        /// Example: A user requests to change the bot‘s language, bot replies to the request with a keyboard to select the new language.Other users in the group don’t see the keyboard.
        /// </summary>
        [DataMember(Name ="selective")]
        public bool Selective { get; set; }

    }
    /// <summary>
    // /Upon receiving a message with this object, Telegram clients will hide the current custom keyboard and display the default letter-keyboard. By default, custom keyboards are displayed until a new keyboard is sent by a bot. An exception is made for one-time keyboards that are hidden immediately after the user presses a button (see ReplyKeyboardMarkup).
    /// </summary>
    [DataContract()]
    public class ReplyKeyboardHide : IReplyMarkup
    {
        /// <summary>
        /// Requests clients to hide the custom keyboard
        /// </summary>
        [DataMember(Name = "hide_keyboard")]
        public bool HideKeyboard { get; set; } = true;

        /// <summary>
        /// Optional. Use this parameter if you want to hide keyboard for specific users only. Targets: 1) users that are @mentioned in the text of the Message object; 2) if the bot's message is a reply (has reply_to_message_id), sender of the original message.
        /// Example: A user votes in a poll, bot returns confirmation message in reply to the vote and hides keyboard for that user, while still showing the keyboard with poll options to users who haven't voted yet.
        /// </summary>
        [DataMember(Name = "selective")]
        public bool Selective { get; set; }
    }

    /// <summary>
    /// Upon receiving a message with this object, Telegram clients will display a reply interface to the user (act as if the user has selected the bot‘s message and tapped ’Reply'). This can be extremely useful if you want to create user-friendly step-by-step interfaces without having to sacrifice privacy mode.
    /// </summary>
    [DataContract()]
    public class ForceReply : IReplyMarkup
    {
        /// <summary>
        /// Shows reply interface to the user, as if they manually selected the bot‘s message and tapped ’Reply'
        /// </summary>
        [DataMember(Name = "force_reply")]
        public bool ForceAReply { get; set; } = true;

        /// <summary>
        /// Optional. Use this parameter if you want to hide keyboard for specific users only. Targets: 1) users that are @mentioned in the text of the Message object; 2) if the bot's message is a reply (has reply_to_message_id), sender of the original message.
        /// Example: A user votes in a poll, bot returns confirmation message in reply to the vote and hides keyboard for that user, while still showing the keyboard with poll options to users who haven't voted yet.
        /// </summary>
        [DataMember(Name = "selective")]
        public bool Selective { get; set; }
    }
}
