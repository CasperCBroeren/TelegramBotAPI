using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TelegramBot.ResponseObjects
{
    public class GetMeResponse
    {
        public bool Ok { get; set; }
        public BotResponse Result { get; set; }
    }
}
