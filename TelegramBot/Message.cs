using System.Runtime.Serialization; 

namespace TelegramBot
{
    /// <summary>
    /// This object represents a message.
    /// </summary>
    [DataContract]
    public class Message    {  
        /// <summary>
        /// Unique message identifier
        /// </summary>
        [DataMember(Name="message_id")]
        public int MessageID	 { get; set; }
        /// <summary>
        /// Optional. Sender, can be empty for messages sent to channels
        /// </summary>
        [DataMember(Name="from")]
        public User From { get; set; }

        /// <summary>
        /// Date the message was sent in Unix time
        /// </summary>
         [DataMember(Name="date")]
        public int Date { get; set; }

        /// <summary>
        /// Conversation the message belongs to
        /// </summary>
         [DataMember(Name="chat")]
        public Chat Chat {get; set;}
        
        /// <summary>
        /// Optional. For forwarded messages, sender of the original message
        /// </summary>
         [DataMember(Name="forward_from")]
        public User ForwardFrom { get; set; }

        /// <summary>
        /// Optional. For messages forwarded from a channel, information about the original channel
        /// </summary>
         [DataMember(Name="forward_from_chat")]
        public Chat ForwardFromChat { get; set; }
        
        /// <summary>
        /// Optional. For forwarded messages, date the original message was sent in Unix time
        /// </summary>
         [DataMember(Name="forward_date")]
        public int ForwardDate { get; set; }
        /// <summary>
        /// Optional. For replies, the original message. Note that the Message object in this field will not contain further reply_to_message fields even if it itself is a reply.
        /// </summary>
        [DataMember(Name="reply_to_message")]
        public Message ReplyToMessage { get; set; }
        /// <summary>
        /// Optional. Date the message was last edited in Unix time
        /// </summary>
        [DataMember(Name="edit_date")]
        public int EditDate { get; set; }
        /// <summary>
        /// Optional. For text messages, the actual UTF-8 text of the message, 0-4096 characters.
        /// </summary>
         [DataMember(Name="text")]
        public string   Text { get; set; }
        /// <summary>
        /// Optional. For text messages, special entities like usernames, URLs, bot commands, etc. that appear in the text
        /// </summary>
         [DataMember(Name="entities")]
        public MessageEntity[] Entities	 { get; set; }
        /// <summary>
        /// Optional. Message is an audio file, information about the file
        /// </summary>
         [DataMember(Name="audio")]
        public Audio Audio { get; set; }
        /// <summary>
        /// Optional. Message is a general file, information about the file
        /// </summary>
        [DataMember(Name="document")]
        public Document Document {get;set;}
        /// <summary>
        /// Optional. Message is a game, information about the game. More about games »
        /// </summary>
        [DataMember(Name="game")]
        public Game Game {get; set;}
        /// <summary>
        /// Optional. Message is a photo, available sizes of the photo
        /// </summary>
        [DataMember(Name="photo")]
        public PhotoSize[] Photos { get; set; }
        /// <summary>
        /// Optional. Message is a sticker, information about the sticker
        /// </summary>
        [DataMember(Name="sticker")]
        public Sticker Sticker { get; set; }
        /// <summary>
        /// Optional. Message is a video, information about the video
        /// </summary>
        [DataMember(Name="video")]
        public Video Video { get; set; }
        /// <summary>
        /// Optional. Message is a voice message, information about the file
        /// </summary>
        [DataMember(Name="voice")]
        public Voice Voice { get; set; }
        /// <summary>
        /// Optional. Caption for the document, photo or video, 0-200 characters
        /// </summary>
        [DataMember(Name="caption")]
        public string Caption { get; set; }
        /// <summary>
        /// Optional. Message is a shared contact, information about the contact
        /// </summary>
        [DataMember(Name="contact")]
        public Contact Contact { get; set; }
        /// <summary>
        /// Optional. Message is a shared location, information about the location
        /// </summary>
        [DataMember(Name="location")]
        public Location  Location { get; set; }
        /// <summary>
        /// Optional. Message is a venue, information about the venue
        /// </summary>
        [DataMember(Name="venue")]
        public Venue Venue { get; set; }
        /// <summary>
        /// Optional. A new member was added to the group, information about them (this member may be the bot itself)
        /// </summary>
        [DataMember(Name="new_chat_member")]
        public User NewChatMember { get; set; }
        /// <summary>
        /// Optional. A member was removed from the group, information about them (this member may be the bot itself)
        /// </summary>
        [DataMember(Name="left_chat_member")]
        public User LeftChatMember { get; set; }
        /// <summary>
        /// Optional. A chat title was changed to this value
        /// </summary>
        [DataMember(Name="new_chat_title")]
        public string NewChatTitle { get; set; }
        /// <summary>
        /// Optional. A chat photo was change to this value
        /// </summary>
        [DataMember(Name="new_chat_photo")]
        public PhotoSize[] NewChatPhoto { get; set; }
        /// <summary>
        /// Optional. Service message: the chat photo was deleted
        /// </summary>
        [DataMember(Name="delete_chat_photo")]
        public bool DeleteChatPhoto { get; set; }
        /// <summary>
        /// Optional. Service message: the group has been created
        /// </summary>
        [DataMember(Name="group_chat_created")]
        public bool GroupChatCreated {get;set;}

        /// <summary>
        /// Optional. Service message: the supergroup has been created. This field can‘t be received in a message coming through updates, because bot can’t be a member of a supergroup when it is created. It can only be found in reply_to_message if someone replies to a very first message in a 
        /// directly created supergroup.
        /// </summary>
        [DataMember(Name="supergroup_chat_created")]
        public bool SuperGroupChatCreated {get;set;}

        /// <summary>
        /// Optional. Service message: the channel has been created. This field can‘t be received in a message coming through updates, because bot can’t be a member of a channel when it is created. It can only be found in reply_to_message if someone replies to a very first message in a channel.
        /// </summary>
        [DataMember(Name="channel_chat_created")]
        public bool ChannelChatCreated {get;set;}

        /// <summary>
        /// Optional. The group has been migrated to a supergroup with the specified identifier. This number may be greater than 32 bits and some programming languages may have difficulty/silent defects in interpreting it. But it smaller than 52 bits, so a signed 64 bit integer or double-precision /// float type are safe for storing this identifier.
        /// </summary>
        [DataMember(Name="migrate_to_chat_id")]
        public int MigrateToChatID { get; set; }

        /// <summary>
        /// Optional. The supergroup has been migrated from a group with the specified identifier. This number may be greater than 32 bits and some programming languages may have difficulty/silent defects in interpreting it. But it smaller than 52 bits, so a signed 64 bit integer or 
        /// double-precision float type are safe for storing this identifier.
        /// </summary>
        [DataMember(Name="migrate_from_chat_id")]
        public int MigrateFromChatID { get; set; }
        /// <summary>
        /// Optional. Specified message was pinned. Note that the Message object in this field will not contain further reply_to_message fields even if it is itself a reply.
        /// </summary>
        [DataMember(Name="pinned_message")]
        public Message PinnedMessage { get; set; }
        
    }
}
