namespace TelegramBot
{
    public class Chat    {
        public int id { get; set;}

        public string type { get; set; }
        public string title { get; set; }

        public string username { get; set; }

        public string first_name { get; set; }

        public string last_name { get; set; }

        public bool all_members_are_administrators { get; set; }

    }
}
