using System.Runtime.Serialization; 

namespace TelegramBot
{
    [DataContract]
    public class Location {

        [DataMember(Name="longitude")]
        public float longitude	 { get; set; }

        [DataMember(Name="latitude")]
        public float Latitude { get; set; } 
        
    }   
}