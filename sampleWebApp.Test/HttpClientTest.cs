using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace sampleWebApp.Test
{
    public class HttpClientTest
    {
        [Fact]
        public async Task should_send_request_to_baidu()
        {
            //Given
            var httpClient = new HttpClient();

            //When
            HttpResponseMessage response = await httpClient.GetAsync("https://wwww.baidu.com");

            //Then
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }



        public void always_return_Redict()
        {
            
        }
    }
}