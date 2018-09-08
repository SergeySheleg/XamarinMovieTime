using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Hello.ViewModels;

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
            context.MovieName = MovieNameEntry.Text;
            context.UpdateList();
        }

    }
}
