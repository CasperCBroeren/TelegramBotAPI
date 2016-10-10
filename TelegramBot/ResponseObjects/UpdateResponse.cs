 using System.Runtime.Serialization;


namespace TelegramBot.ResponseObjects
{
    [DataContract]
    public class UpdateResponse : BaseResponse
    {
        [DataMember(Name ="result")]
        public Update[] Result { get; set; }
    }
}
