using Hello.Helpers;
using Hello.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Hello.ViewModels
{
    class AlreadyWatchedViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Movie> Items { get; set; } = new ObservableCollection<Movie>();

        public AlreadyWatchedViewModel()
        {
            ImdbApiTest();
        }

        async void ImdbApiTest() {
            //var movie = await new ImdbApi().getMovieByIdAsync();
            //Items.Add(movie);

            var list = await new ImdbApi().searchMoviesByNameAsync("matrix");
            foreach (var l in list) {
                Items.Add(l);
            }
        }
        
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
