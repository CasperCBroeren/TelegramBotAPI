using System.Runtime.Serialization; 

namespace TelegramBot
{
    [DataContract]
    public class InlineQuery {

        [DataMember(Name="id")]
        public int ID { get; set; }

        [DataMember(Name="from")]
        public User From { get; set; } 
        
        [DataMember(Name="location")]
        public Location Location { get; set; }

        [DataMember(Name="query")]
        public string Query { get; set; }

        [DataMember(Name="offset")]
        public string Offset { get; set; }

    }   
}