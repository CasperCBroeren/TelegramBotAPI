using System.Runtime.Serialization; 

namespace TelegramBot
{
    [DataContract]
    public class MessageEntity {

        [DataMember(Name="type")]
        public string Type { get; set; }

        [DataMember(Name="offset")]
        public int Offset { get; set; } 
        
        [DataMember(Name="length")]
        public int Length { get; set; }

        [DataMember(Name="url")]
        public string URL { get; set; }

        [DataMember(Name="user")]
        public User User { get; set; }

    }   
}