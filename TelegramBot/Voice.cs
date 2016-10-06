using System.Runtime.Serialization; 

namespace TelegramBot
{
    [DataContract]
    public class Voice {

        [DataMember(Name="file_id")]
        public string FileID	 { get; set; }
 
        [DataMember(Name="duration")]
        public int Duration { get; set; }

         
        [DataMember(Name="mime_type")]
        public string MimeType { get; set; } 
         

        [DataMember(Name="file_size")]
        public int FileSize { get; set; }
        
    }   
}