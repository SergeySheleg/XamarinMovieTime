using Hello.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Hello.Services
{

    class IMDBDataProvider
    {
        static private string ImdbUrl = "http://www.omdbapi.com/";
        public string ImdbApiKey { get; set; } = "ce6832f4";

        public async Task<Movie> GetMovieByIdAsync(string id = "tt3896198") {
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
        public async Task<IEnumerable<Movie>> SearchMoviesByNameAsync(string name)
        {
            if (name == "")
            {
                return new List<Movie>();
            }
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

                    var searchToken = o.SelectToken(@"$.Search");
                    return JsonConvert.DeserializeObject<IEnumerable<Movie>>(searchToken.ToString());
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.Write(e.ToString(), "IMDBDataProvider Error");
                }
            }

            return new List<Movie>();
        }

        public ObservableCollection<Movie> Items { get; set; } = new ObservableCollection<Movie>();
    }
}
