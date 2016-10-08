using System.Runtime.Serialization;

namespace TelegramBot.ResponseObjects
{
    [DataContract]
    public class BaseResponse
    {
        [DataMember(Name = "ok")]
        public bool Ok { get; set; }

        [DataMember(Name = "description")]
        public string Description { get; set; }

        [DataMember(Name = "error_code")]
        public int ErrorCode { get; set; }
    }
}