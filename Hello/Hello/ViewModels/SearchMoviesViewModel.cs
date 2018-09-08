using Hello.Helpers;
using Hello.Models;
using Hello.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Hello.ViewModels
{
    class SearchMoviesViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Movie> Items { get; set; } = new ObservableCollection<Movie>();

        public SearchMoviesViewModel()
        {
        }

        public string MovieName { get; set; }

        public async void UpdateList() {
            var imdb = new IMDBDataProvider();
            var movies = await imdb.SearchMoviesByNameAsync(MovieName);
            
            Items.Clear();
            foreach (var m in movies) {
                Items.Add(m);
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
