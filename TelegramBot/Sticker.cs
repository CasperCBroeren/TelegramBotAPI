using System.Runtime.Serialization; 

namespace TelegramBot
{
    [DataContract]
    public class Sticker {

        [DataMember(Name="file_id")]
        public string FileID	 { get; set; }
 
        [DataMember(Name="width")]
        public int Width { get; set; }

        [DataMember(Name="height")]
        public int Height { get; set; } 

        [DataMember(Name="thumb")]
        public PhotoSize Thumb { get; set; }
        
        [DataMember(Name="emoji")]
        public string Emoji { get; set; } 
         

        [DataMember(Name="file_size")]
        public int FileSize { get; set; }
        
    }   
}