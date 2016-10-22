using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TelegramBot.RequestObjects
{
    public class BasicToSend: IToSend
    {
        public string Method { get; set; }

        public string URL { get; set; }

        public int? Limit { get; set; }
        public int? Offset { get; set; }

        public int? Timeout { get; set; }

        public object Payload { get; set; }
    }
}
