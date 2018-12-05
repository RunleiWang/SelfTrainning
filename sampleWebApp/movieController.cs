using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace sampleWebApp
{
    public class personController : Controller
    {
       
        
        List<string> _person = new List<string>
        {
            "runlei",
            "leilei",
            "xiaxia"
        };

        [Route("/person")]
        public IEnumerable<string> Index()
        {
            return _person;
        }
        
    }
}