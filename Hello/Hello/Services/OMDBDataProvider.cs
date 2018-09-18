using Hello.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Hello.Services
{

    class OMDBDataProvider
    {
        static private string OmdbUrl = "http://www.omdbapi.com/";
        public string OmdbApiKey { get; set; } = "ce6832f4";

        public async Task<Movie> GetMovieByIdAsync(string id = "tt3896198") {
            string url = OmdbUrl + "?i=" + id + "&plot=full"+ "&apikey=" + OmdbApiKey;

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
            var list = new List<Movie>();
            

            if (String.IsNullOrEmpty(name))
            {
                return list;
            }

            uint page = 1;

            //string url = ImdbUrl + "?s=" + name + "&apikey=" + ImdbApiKey;
            

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    while (true) {
                        string url = OmdbUrl + "?apikey=" + OmdbApiKey + "&s=" + Uri.EscapeUriString(name) + "&page=" + page + "&type=movie";

                        client.BaseAddress = new Uri(url);
                        var response = await client.GetAsync(client.BaseAddress);
                        response.EnsureSuccessStatusCode();

                        var content = await response.Content.ReadAsStringAsync();
                        JObject o = JObject.Parse(content);
                        bool omdb_response = o.Value<bool>("Response");
                        if (!omdb_response) {
                            break;
                        }

                        //int totalResults = o.Value<int>("totalResults");

                        var searchToken = o.SelectToken(@"$.Search");
                        //return JsonConvert.DeserializeObject<IEnumerable<Movie>>(searchToken.ToString());

                        list.AddRange(JsonConvert.DeserializeObject<List<Movie>>(searchToken.ToString()));
                        page++;
                    }
                    
                }
                catch (Exception e)
                {
                    Debug.Write(e.ToString(), "OMDBDataProvider Error");
                }
            }

            return list;
        }

        public ObservableCollection<Movie> Items { get; set; } = new ObservableCollection<Movie>();
    }
}
