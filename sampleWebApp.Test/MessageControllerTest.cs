using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;

namespace sampleWebApp.Test
{
    public class MessageControllerTest : TestHelper
    {
        
        [Fact]
        public async Task should_get_response()
        {           
            var response = await Client.GetAsync("home");           
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
        
        [Fact]
        public async Task should_return_not_fund_when_route_request_not_match()
        {             
            var response = await Client.GetAsync("homes");            
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task should_get_correct_header()
        {
            var response = await Client.GetAsync("home");
            IEnumerable<string> headerValues;
            var responseHeaders = response.Headers.TryGetValues("My-Headers", out headerValues); //bool
            var actualValue = response.Headers.GetValues("My-Headers").FirstOrDefault();
            
            Assert.True(responseHeaders);
            Assert.Equal("my-headers",actualValue);
                        
        }

        [Fact]
        public async Task should_return_error_when_capture_exception()
        {
            var httpRequest = new HttpRequestMessage(HttpMethod.Post, "About")
            {
                Content = new StringContent("should throw an error", Encoding.UTF8,"application/json")                
            };
            var response = await Client.SendAsync(httpRequest);  //HttpResponseMessage
            Assert.Equal(HttpStatusCode.InternalServerError, response.StatusCode);

        }

        [Fact]
        public async Task should_return_correct_json_data()
        { 
            var response = await Client.GetAsync("home"); //HttpResponseMessage
            var responseString = response.Content.ReadAsStringAsync().Result;
            JObject obj =JsonConvert.DeserializeObject<JObject>(responseString);            
            Assert.Equal("Disney", obj.GetValue("1"));            
        }


        [Fact]
        public async Task should_get_correct_body_from_request()
        {          
            
            var testData = new Dictionary<string,string>
            {
                {"ID", "string"},
                {"Name", "Good"},
                {"Country","IR"},
                {"Description","Love"},
                {"Test","test"},
                {"Cast", "1233"}                
            };            

            var stringRequest = JsonConvert.SerializeObject(testData);
            HttpRequestMessage postRequest = new HttpRequestMessage(HttpMethod.Post, "home/create-movie/5")
            {
                Content = new StringContent("123",Encoding.UTF8,"application/json")
            };
           
            var response = await Client.SendAsync(postRequest);  //HttpResponseMessage
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);            

        }
        
    } 
}