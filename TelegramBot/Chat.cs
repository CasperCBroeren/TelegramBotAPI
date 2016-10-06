
using System.Runtime.Serialization;

namespace TelegramBot
{
    [DataContract]
    public class Chat    {
        
       [DataMember(Name="id")]
       
        public int ID { get; set;}
       [DataMember(Name="type")]

        public string Type { get; set; }

       [DataMember(Name="title")]
        public string Title { get; set; }

       [DataMember(Name="username")]
        public string Username { get; set; }

       [DataMember(Name="first_name")]
        public string FirstName { get; set; }

       [DataMember(Name="last_name")]
        public string LastName { get; set; }

       [DataMember(Name="all_members_are_administrators")]
        public bool AllMembersAreAdministrators { get; set; }

    }
}
