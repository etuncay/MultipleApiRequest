using System;
using RestSharp;
using System.Collections.Generic;
namespace MAR.Api.Models
{
    public class RequestModel
    {
        public string Name { get; set; }
        public string Resource { get; set; }
        public Method Method { get; set; }
        public List<KeyValueModel> Data { get; set; } = new List<KeyValueModel>();
    }
}
