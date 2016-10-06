using System.Runtime.Serialization;

namespace TelegramBot
{
    [DataContract]
    public class Update
    {

        [DataMember(Name="update_id")]
        public int UpdateID { get; set; }
        [DataMember(Name="message")]
        public Message Message { get; set; }
        
        [DataMember(Name="edited_message")]
        public Message EditedMessage { get; set; }
      
    }
}
