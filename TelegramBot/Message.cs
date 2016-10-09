using System.Runtime.Serialization; 

namespace TelegramBot
{
    [DataContract]
    public class Message    {  
        [DataMember(Name="message_id")]
        public int MessageID	 { get; set; }

        [DataMember(Name="from")]
        public User From { get; set; }

         [DataMember(Name="date")]
        public int Date { get; set; }

         [DataMember(Name="chat")]
        public Chat Chat {get; set;}
        
         [DataMember(Name="forward_from")]
        public User ForwardFrom { get; set; }

         [DataMember(Name="forward_from_chat")]
        public Chat ForwardFromChat { get; set; }
         [DataMember(Name="forward_date")]
        public int ForwardDate { get; set; }
         [DataMember(Name="reply_to_message")]
        public Message ReplyToMessage { get; set; }

         [DataMember(Name="edit_date")]
        public int EditDate { get; set; }

         [DataMember(Name="text")]
        public string   Text { get; set; }

         [DataMember(Name="entities")]
        public MessageEntity[] Entities	 { get; set; }

         [DataMember(Name="audio")]
        public Audio Audio { get; set; }

        [DataMember(Name="document")]
        public Document Document {get;set;}
        
        [DataMember(Name="game")]
        public Game Game {get; set;}
        
        [DataMember(Name="photo")]
        public PhotoSize[] Photos { get; set; }

        [DataMember(Name="sticker")]
        public Sticker Sticker { get; set; }

        [DataMember(Name="video")]
        public Video Video { get; set; }

        [DataMember(Name="voice")]
        public Voice Voice { get; set; }
        
        [DataMember(Name="caption")]
        public string Caption { get; set; }

        [DataMember(Name="contact")]
        public Contact Contact { get; set; }

        [DataMember(Name="location")]
        public Location  Location { get; set; }

        [DataMember(Name="venue")]
        public Venue Venue { get; set; }

        [DataMember(Name="new_chat_member")]
        public User NewChatMember { get; set; }

        [DataMember(Name="left_chat_member")]
        public User LeftChatMember { get; set; }

        [DataMember(Name="new_chat_title")]
        public string NewChatTitle { get; set; }

        [DataMember(Name="new_chat_photo")]
        public PhotoSize[] NewChatPhoto { get; set; }

        [DataMember(Name="delete_chat_photo")]
        public bool DeleteChatPhoto { get; set; }

        [DataMember(Name="group_chat_created")]
        public bool GroupChatCreated {get;set;}


        [DataMember(Name="supergroup_chat_created")]
        public bool SuperGroupChatCreated {get;set;}


        [DataMember(Name="channel_chat_created")]
        public bool ChannelChatCreated {get;set;}

        [DataMember(Name="migrate_to_chat_id")]
        public int MigrateToChatID { get; set; }


        [DataMember(Name="migrate_from_chat_id")]
        public int MigrateFromChatID { get; set; }
        
        [DataMember(Name="pinned_message")]
        public Message PinnedMessage { get; set; }
        
    }
}
