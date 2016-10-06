using System.Runtime.Serialization; 

namespace TelegramBot
{
    [DataContract]
    public class Venue {

        [DataMember(Name="title")]
        public string Title	 { get; set; }
 
        [DataMember(Name="address")]
        public string Address { get; set; }

         
        [DataMember(Name="foursquare_id")]
        public string FoursquareID { get; set; } 
         

        [DataMember(Name="location")]
        public Location Location { get; set; }
        
    }   
}