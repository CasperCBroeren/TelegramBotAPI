using System.Runtime.Serialization;


namespace TelegramBot
{
    [DataContract]
    public class User    {
        [DataMember(Name="id")]
        public int ID { get; set;}

        [DataMember(Name="first_name")]
        public string  FirstName { get; set; }

        [DataMember(Name="last_name")]
        public string LastName { get; set; }

        [DataMember(Name="username")]
        public string Username { get; set; }
        
    }
}
