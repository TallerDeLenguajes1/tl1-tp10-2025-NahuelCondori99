namespace Nacionalidad
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Country
    {
        //[JsonProperty("country_id")]
        public string country_id { get; set; }

        //[JsonProperty("probability")]
        public double probability { get; set; }
    }

    public class Nacion
    {
        //[JsonProperty("count")]
        public int count { get; set; }

        //[JsonProperty("name")]
        public string name { get; set; }

        //[JsonProperty("country")]
        public List<Country> country { get; set; }
    }
}