using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Xunit;

namespace sampleWebApp.Test
{
    public class MessageControllerTest
    {
        [Fact]
        public async Task should_get_message()
        {
            //Attach mvc app to http client
            var builder = new WebHostBuilder().UseStartup<Startup>();
            var testServer = new TestServer(builder);
            var httpClient = testServer.CreateClient();  //Create handler
            
            //send get request to mvc app
            var response = await httpClient.GetAsync("/home");
            
            //
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}