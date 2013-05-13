﻿using System;
using System.Net;
using System.Windows;
using System.Windows.Input;
using System.Runtime.Serialization;
using System.Collections.Generic;

namespace Twitter_Tools.Services
{
    [DataContract]
    public class TopsyContent
    {
        [DataMember]
        public string content { get; set; }
        [DataMember]
        public string topsy_author_img { get; set; }
        [DataMember]
        public string trackback_author_name { get; set; }
        [DataMember]
        public string title { get; set; }
    }

    [DataContract]
    public class Response
    {
        [DataMember]
        public int page { get; set; }
        [DataMember]
        public int total { get; set; }
        [DataMember]
        public int perpage { get; set; }
        [DataMember]
        public List<TopsyContent> list { get; set; }
    }
    [DataContract]
    public class TopsyTwit
    {
        [DataMember]
        public Response response { get; set; }
    }
}
