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
using Hello.Models;

namespace Hello.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WantToWatchTab : ContentPage
    {
        WantToWatchViewModel viewModel = new WantToWatchViewModel();
        public WantToWatchTab()
        {
            InitializeComponent();
            BindingContext = viewModel;
            startInitViewModelAsync();
        }

        async void startInitViewModelAsync()
        {
            await viewModel.InitAsync();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Movie;
            if (item == null)
                return;

            await Navigation.PushAsync(new DetailViewWantToWatchPage(new DetailMovieLocalViewModel(item)));
            
            MoviesListView.SelectedItem = null;
        }

    }
}
