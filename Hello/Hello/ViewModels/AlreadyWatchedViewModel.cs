using Hello.Helpers;
using Hello.Models;
using Hello.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Hello.ViewModels
{
    class AlreadyWatchedViewModel : BaseViewModel
    {
        private AlreadyWatchedMoviesLocalDataStore LocalDataStorege = AlreadyWatchedMoviesLocalDataStore.Current;

        public ObservableCollection<Movie> Items { get; set; } = new ObservableCollection<Movie>();

        public AlreadyWatchedViewModel() {
            MessagingCenter.Subscribe<AlreadyWatchedMoviesLocalDataStore, Movie>(this, "AddItem", (obj, item) =>
            {
                var newItem = item as Movie;
                Items.Add(newItem);
            });

            MessagingCenter.Subscribe<AlreadyWatchedMoviesLocalDataStore, Movie>(this, "DeleteItem", (obj, item) =>
            {
                var m = item as Movie;
                Items.Remove(m);
            });
        }

        public async Task InitAsync()
        {
            var storedMovies = await LocalDataStorege.GetItemsAsync();

            foreach (var m in storedMovies)
            {
                Items.Add(m);
            }
        }
    }
}
