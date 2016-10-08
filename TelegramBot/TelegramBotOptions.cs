using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TelegramBot
{
    public sealed class TelegramBotOptions
    {
        public string Host { get; set; } = "api.telegram.org";

        public int Port { get; set; } = 443;
    }
}
