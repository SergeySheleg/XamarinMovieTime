using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Hello.ViewModels;
using Hello.Models;

namespace Hello.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchTab : ContentPage
    {
        SearchMoviesViewModel context = new SearchMoviesViewModel();
        public SearchTab()
        {
            InitializeComponent();
            BindingContext = context;



        }

        //public void EntryMovieName_onTextChanged(object sender, TextChangedEventArgs e) {
        //    context.MovieName = e.NewTextValue;
        //    context.UpdateList();
        //}

        public void SearchButton_onClicked() {
            //context.MovieName = MovieNameEntry.Text;
            context.MovieName = MovieName.Text;
            context.UpdateList();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Movie;
            if (item == null)
                return;

            await Navigation.PushAsync(new DetailMovieSearchPage(new DetailMovieSearchViewModel(item)));

            // Manually deselect item.
            MoviesListView.SelectedItem = null;
        }

    }
}
