using System.Runtime.Serialization;

namespace TelegramBot.ResponseObjects
{
    [DataContract]
    public class BotResponse
    {
        [DataMember(Name = "id")]
        public int ID { get; set; }
        [DataMember(Name = "username")]
        public string UserName { get; set; }


    }
}
