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
    public partial class DetailViewWantToWatchPage : ContentPage
    {

        DetailMovieLocalViewModel viewModel;
        public DetailViewWantToWatchPage()
        {
            InitializeComponent();
        }
        public DetailViewWantToWatchPage(DetailMovieLocalViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = this.viewModel = viewModel;
        }


        public async void MoveToAlreadyWatch()
        {
            viewModel.MoveToAlreadyWatch();
            try
            {
                await Navigation.PopAsync();
            }
            catch (Exception e)
            {
                Debug.Write(e);
            }
        }

        public async void Remove()
        {
            viewModel.RemoveFromWantToWatch();
            try
            {
                await Navigation.PopAsync();
            }
            catch (Exception e)
            {
                Debug.Write(e);
            }

        }
    }
}