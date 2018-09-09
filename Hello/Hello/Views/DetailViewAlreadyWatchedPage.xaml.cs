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


        public void MoveToWantToWatch()
        {
            viewModel.MoveToWantToWatch();
        }

        public void Remove()
        {
            viewModel.RemoveFromAlreadyWatch();

        }
    }
}