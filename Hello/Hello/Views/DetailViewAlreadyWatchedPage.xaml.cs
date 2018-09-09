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
    public partial class DetailViewAlreadyWatchedPage : ContentPage
    {

        DetailMovieLocalViewModel viewModel;
        public DetailViewAlreadyWatchedPage()
        {
            InitializeComponent();
        }
        public DetailViewAlreadyWatchedPage(DetailMovieLocalViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = this.viewModel = viewModel;
        }


        public async void MoveToWantToWatch()
        {
            viewModel.MoveToWantToWatch();
            try
            {
                await Navigation.PopAsync();
            }
            catch (Exception e) {
                Debug.Write(e);
            }
        }

        public async void Remove()
        {
            viewModel.RemoveFromAlreadyWatch();
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