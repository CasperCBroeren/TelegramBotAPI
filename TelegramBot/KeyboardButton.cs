

using System.Runtime.Serialization;

namespace TelegramBot
{
    /// <summary>
    /// This object represents one button of the reply keyboard. For simple text buttons String can be used instead of this object to specify text of the button. Optional fields are mutually exclusive.
    /// </summary>
   [DataContract()]
    public class KeyboardButton
    {
        /// <summary>
        /// Text of the button. If none of the optional fields are used, it will be sent to the bot as a message when the button is pressed
        /// </summary>
        [DataMember(Name ="text")]
        public string Text { get; set; }
        /// <summary>
        /// Optional. If True, the user's phone number will be sent as a contact when the button is pressed. Available in private chats only
        /// </summary>
        [DataMember(Name = "request_contact")]
        public bool RequestContact { get; set; }

        /// <summary>
        /// Optional. If True, the user's current location will be sent when the button is pressed. Available in private chats only
        /// </summary>
        [DataMember(Name ="request_location")]
        public bool RequestLocation { get; set; }
    }
}
