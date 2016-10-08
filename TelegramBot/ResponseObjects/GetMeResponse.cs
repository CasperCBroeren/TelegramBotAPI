using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace TelegramBot.ResponseObjects
{
    [DataContract]
    public class GetMeResponse : BaseResponse
    {
        [DataMember(Name = "result")]
        public BotResponse Result { get; set; }
    }
}
