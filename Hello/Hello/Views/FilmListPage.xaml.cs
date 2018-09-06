using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Hello.ViewModels;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


using System.Net.Http;

namespace Hello.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FilmListPage : ContentPage
    {
        public FilmListPage()
        {
            InitializeComponent();
            BindingContext = new WatchedFilmsViewModel();
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            await DisplayAlert("Item Tapped", "An item was tapped.", "OK");

            //Deselect Item
            ((ListView)sender).SelectedItem = null;

            LoadData();
        }

        public class RateInfo
        {
            public string Title { get; set; }
            public string Year { get; set; }
        }

        private async void LoadData()
        {
            string url = "http://www.omdbapi.com/?i=tt3896198&apikey=ce6832f4";

            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(url);
                var response = await client.GetAsync(client.BaseAddress);
                response.EnsureSuccessStatusCode(); // выброс исключения, если произошла ошибка

                // десериализация ответа в формате json
                var content = await response.Content.ReadAsStringAsync();
                JObject o = JObject.Parse(content);

                var str = o.SelectToken(@"$");
                var rateInfo = JsonConvert.DeserializeObject<RateInfo>(str.ToString());

                //this.Rate = rateInfo.Rate;
                //this.Ask = rateInfo.Ask;
                //this.Bid = rateInfo.Bid;
            }
            catch (Exception ex)
            { }
        }
    }
}
