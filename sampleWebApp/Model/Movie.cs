namespace sampleWebApp
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string Description { get; set;}
        public Cast Cast { get; set; }
    }

    public class Cast
    {
        public int CastKey { get; set; }
        public string CastName { get; set; }
        public string CastCountry { get; set; }        
    }
}