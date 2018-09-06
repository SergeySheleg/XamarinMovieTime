using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Hello.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Hello.Helpers
{
    class ImdbApi
    {
        static string ImdbUrl = "http://www.omdbapi.com/";
        //string search(string name) {
        //    return "&s=" + name;
        //}

        //string apikey(string key) {
        //    return "&apikey=" + key;
        //}

        //string id(string id)
        //{
        //    return "?i=" + id;
        //}

        public string ImdbApiKey { get; set; } = "ce6832f4";
        public async Task<Movie> getMovieByIdAsync(string id = "tt3896198")
        {
            string url = ImdbUrl + "?i=" + id + "&apikey=" + ImdbApiKey;

            Movie movie;

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri(url);
                    var response = await client.GetAsync(client.BaseAddress);
                    response.EnsureSuccessStatusCode();

                    var content = await response.Content.ReadAsStringAsync();
                    JObject o = JObject.Parse(content);

                    var str = o.SelectToken(@"$");
                    movie = JsonConvert.DeserializeObject<Movie>(str.ToString());
                }
                catch (Exception e)
                {
                    System.Console.Error.Write("Error: {}\n", e.ToString());
                    movie = new Movie();
                }
            }

            return movie;
        }

        public async Task<IEnumerable<Movie>> searchMoviesByNameAsync(string name)
        {
            string url = ImdbUrl + "?s=" + name + "&apikey=" + ImdbApiKey;
            
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri(url);
                    var response = await client.GetAsync(client.BaseAddress);
                    response.EnsureSuccessStatusCode();

                    var content = await response.Content.ReadAsStringAsync();
                    JObject o = JObject.Parse(content);

                    //TODO: FIX SelectToken arg
                    //var responseToken = o.SelectToken(@"$.Response");
                    //if (!JsonConvert.DeserializeObject<bool>(responseToken.ToString())) {
                    //    return new List<Movie>();;
                    //}

                    var searchToken = o.SelectToken(@"$.Search");
                    return JsonConvert.DeserializeObject<IEnumerable<Movie>>(searchToken.ToString());
                }
                catch (Exception e)
                {
                    System.Console.Error.Write("Error: {}\n", e.ToString());
                }
            }
            
            return new List<Movie>();
        }
    }
}
