using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TelegramBot.RequestObjects
{
    public interface IToSend
    {
          string Method { get; set; }
        string URL { get; set; }

        int? Limit { get; set; }

        int? Offset { get; set; }

          int? Timeout { get; set; }
         
    }
}
