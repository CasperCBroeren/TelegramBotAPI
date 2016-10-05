
namespace TelegramBot
{
    public class MessageEntity {
        public string type { get; set; }
        public int offset { get; set; }
        public int length { get; set; }
        public string url { get; set; }
        public User user { get; set; }

    }   
}