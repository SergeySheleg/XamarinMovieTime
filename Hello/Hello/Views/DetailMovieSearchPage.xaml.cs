using Hello.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Hello.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DetailMovieSearchPage : ContentPage
	{
        DetailMovieSearchViewModel viewModel;
        public DetailMovieSearchPage()
		{
			InitializeComponent ();
		}

        public DetailMovieSearchPage(DetailMovieSearchViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = this.viewModel = viewModel;
        }

        public async void AddToWantToWatch()
        {
            viewModel.AddToWantToWatch();
            try
            {
                await Navigation.PopAsync();
            }
            catch (Exception e)
            {
                Debug.Write(e);
            }
        }

        public async void AddToAlreadyWatch()
        {
            viewModel.AddToAlreadyWatch();
            try
            {
                await Navigation.PopAsync();
            }
            catch (Exception e)
            {
                Debug.Write(e);
            }
        }
        public void OpenURL()
        {
            Device.OpenUri(new Uri("https://www.imdb.com/title/" + viewModel.Movie.imdbID));
        }
    }
}