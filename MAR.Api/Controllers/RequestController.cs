using Microsoft.AspNetCore.Mvc;
using MAR.Api.Models;
using RestSharp;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MAR.Api.Controllers
{
    [Route("api/[controller]")]
    public class RequestController : Controller
    {
        // GET api/values
        [HttpPost]
        public Dictionary<string, object> Post([FromBody]List<RequestModel> requestItems)
        {

           /* var requestItems = new List<RequestModel>{
                new RequestModel{
                    Name = "personData",
                    Resource = "person",
                    Method = Method.GET,
                },
                new RequestModel{
                    Name = "cityData",
                    Resource = "city",
                    Method = Method.GET,
                },

            };*/



            var client = new RestClient("http://localhost:5000/api");

            var result = new Dictionary<string, object>();

            foreach (var item in requestItems)
            {
                
                var request = new RestRequest(item.Resource, item.Method);

                if(item.Data.Any()){
                    foreach (var keyValue in item.Data)
                    {
                        request.AddParameter(new Parameter
                        {
                            Name = keyValue.Key,
                            Value = keyValue.Value
                        });
                    }    
                }

                IRestResponse response =  client.Execute(request);

                var content = Newtonsoft.Json.JsonConvert.DeserializeObject<object>(response.Content);

                result.Add(item.Name, content);
            }




            return result;
        }

    }
}
