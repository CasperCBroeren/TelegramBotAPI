using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TelegramBot.ResponseObjects
{
    public class MessageResponse: BaseResponse
    {
        public Message Message { get; set; }
    }
}
