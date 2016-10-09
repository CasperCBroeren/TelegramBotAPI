using System.Runtime.Serialization;

namespace TelegramBot
{
    [DataContract]
    public class Game
    {
        [DataMember(Name="title")]
        public string Title{get;set;}

        [DataMember(Name="description")]
        public string Description{get;set;}

        [DataMember(Name="photo")]
        public PhotoSize[] Photo { get; set; }

        [DataMember(Name="text")]
        public string Text { get; set; }  

        [DataMember(Name="text_entities")]
        public MessageEntity[] TextEntities { get; set; } 

        [DataMember(Name="animation")]
        public Animation  Animation { get; set; } 
    }
}