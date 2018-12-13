using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


namespace sampleWebApp
{
    public class MovieController : Controller
    {
        private readonly List<Movie> _movie = new List<Movie>
        {
            new Movie{Id = 1,Name = "Disney", Country = "FR", Description = "Cartoon", Cast = new Cast{CastKey = 1, CastCountry = "CN", CastName = "Lei Wang"}},
            new Movie{Id = 2,Name = "Marvel", Country = "US", Description = "Action", Cast = new Cast{CastKey = 1, CastCountry = "CN", CastName = "RunLei Wang"}},
            new Movie{Id = 3,Name = "Youth", Country = "CN", Description = "Romantic", Cast = new Cast{CastKey = 1, CastCountry = "CN", CastName = "Xia Liu"}},
            new Movie{Id = 4,Name = "Love", Country = "IR", Description = "Romantic", Cast = new Cast{CastKey = 1, CastCountry = "CN", CastName = "Run wang"}}
        };
        
        [HttpPost("/About")]
        public ActionResult getParaFromBody([FromBody]Movie movieFromBody)
        {
            if (!ModelState.IsValid)
            {
                throw new Exception("oops,error");
                //return BadRequest(ModelState);  //bad request              
            }
            return Json(movieFromBody);
        }
        
        //Create new Movie
        [HttpPost("home/create-movie/{name}")]
        public ActionResult createMovie(int id, [FromQuery] string name, [FromBody]Cast castFromBody)
        {
            var newMovie = new Movie{Id = id,Name = name,Cast = castFromBody};  //new object
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Json(newMovie);
        }
        
        [HttpGet("/home")]
        public IActionResult getMovies()
        {
            var request = Request;
            request.HttpContext.Response.Headers.Add("My-Headers","my-headers");
            var nameArray = new Dictionary<int, string>();           
            foreach (var movie in _movie)
            {
                nameArray.Add(movie.Id, movie.Name);
            }           
            var jsonResponse = JsonConvert.SerializeObject(nameArray);
            if (!ModelState.IsValid)
            {
                throw new Exception("oops,error");
            }
            return Ok(jsonResponse);  
        }
               
        [HttpGet("/home/details/{id?}")]
        public ActionResult movieDetail(int id)
        {                  
            var request = Request;
            request.HttpContext.Response.Headers.Add("My-Headers","my-headers");
            var response = new HttpResponseMessage(HttpStatusCode.OK);
            if (response.IsSuccessStatusCode)
            {
                //return Json(request.Headers);  //get headers
            }
            if (id > 2)
            {
                return Json(response.StatusCode); //404
            }           
            return Ok(_movie[id]);  //okay 200          
        }

       
        
    }
}