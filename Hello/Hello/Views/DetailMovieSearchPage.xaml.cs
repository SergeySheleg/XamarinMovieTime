using Hello.ViewModels;
using System;
using System.Collections.Generic;
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

        public void AddToWantToWatch()
        {
            viewModel.AddToWantToWatch();
        }

        public void AddToAlreadyWatch()
        {
            viewModel.AddToAlreadyWatch();
        }
    }
}