using System;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc.Testing;

namespace sampleWebApp.Test
{
    public abstract class TestHelper : IDisposable
    {
        protected static HttpClient Client { get; private set; }

        protected TestHelper()
        { 
            Client = new WebApplicationFactory<Startup>().CreateClient();
        }

        public void Dispose()
        {
            Client.Dispose();
        }
    }

}



//Notes
//        private readonly WebApplicationFactory<Startup> _factory;        
//        private HttpClient Client { get;}
//        
//      
//        
//        //basic
//        public MessageControllerTest(WebApplicationFactory<Startup> factory)
//        {
//            _factory = factory;
//  
//            var builder = new WebApplicationFactory<Startup>();
//            
//            Client = builder.CreateClient();
//            Client.BaseAddress = new Uri("http://localhost:5000/home");            
//        }