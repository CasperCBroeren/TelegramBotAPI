using System.Runtime.Serialization; 

namespace TelegramBot
{
    [DataContract]
    public class ChosenInlineResult {

        [DataMember(Name="result_id")]
        public string ResultID	 { get; set; }

        [DataMember(Name="from")]
        public User From { get; set; } 

        [DataMember(Name="location")]
        public Location  Location { get; set; }


        [DataMember(Name="inline_message_id")]
        public string InlineMessageID	 { get; set; }


        [DataMember(Name="query")]
        public string Query	 { get; set; }
        
    }   
}