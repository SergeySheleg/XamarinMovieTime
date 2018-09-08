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
	public partial class DetailMoviePage : ContentPage
	{
        DetailMovieViewModel viewModel;
        public DetailMoviePage ()
		{
			InitializeComponent ();
		}

        public DetailMoviePage (DetailMovieViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = this.viewModel = viewModel;
        }

        public void AddToWantToWatch()
        {
            
        }

        public void AddToAlreadyWatch()
        {
            viewModel.AddToAlreadyWatch();
        }
    }
}