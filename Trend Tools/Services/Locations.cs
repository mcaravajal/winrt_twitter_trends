using System;
using System.Net;
using System.Windows;
using System.Windows.Input;
using System.Runtime.Serialization;
using System.ComponentModel;

namespace Twitter_Tools.Services
{
    [DataContract]
    public class Locations
    {
        [DataMember]
        public int country_name { get; set; }
        [DataMember]
        public string name {get;set;}
        [DataMember]
        public int place_type_code { get; set; }
        [DataMember]
        public string place_type_name { get; set; }
        [DataMember]
        public int woeid { get; set; }
        
    }
    [DataContract]
    public class LocationsResults
    {
        [DataMember]
        public Locations[] locations { get; set; }
    }
}
