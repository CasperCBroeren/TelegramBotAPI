using System.Runtime.Serialization; 

namespace TelegramBot
{
    [DataContract]
    public class Document {

        [DataMember(Name="file_id")]
        public string FileID	 { get; set; }
 
        [DataMember(Name="thumb")]
        public PhotoSize Thumb { get; set; }
        
        [DataMember(Name="file_name")]
        public string FileName { get; set; } 
        
        [DataMember(Name="mime_type")]
        public string MimeType { get; set; } 


        [DataMember(Name="file_size")]
        public int FileSize { get; set; }
        
    }   
}