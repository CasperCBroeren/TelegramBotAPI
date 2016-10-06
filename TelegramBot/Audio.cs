using System.Runtime.Serialization; 

namespace TelegramBot
{
    [DataContract]
    public class Audio {

        [DataMember(Name="file_id")]
        public string FileID	 { get; set; }

        [DataMember(Name="duration")]
        public int Duration { get; set; }

        [DataMember(Name="performer")]
        public string Performer { get; set; } 
        
        [DataMember(Name="title")]
        public string Title { get; set; } 
        
        [DataMember(Name="mime_type")]
        public string MimeType { get; set; } 


        [DataMember(Name="file_size")]
        public int FileSize { get; set; }
        
    }   
}