using Hello.Helpers;
using Hello.Models;
using Hello.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Hello.ViewModels
{
    class SearchMoviesViewModel : BaseViewModel
    {
        public ObservableCollection<Movie> Items { get; set; } = new ObservableCollection<Movie>();

        public SearchMoviesViewModel()
        {
        }

        public string MovieName { get; set; }




        public async void UpdateList() {
            if (IsBusy) {
                return;
            }
            IsBusy = true;
            Title = "Search...";
            try
            {
                var imdb = new OMDBDataProvider();
                var movies = await imdb.SearchMoviesByNameAsync(MovieName);

                uint size = 0;

                Items.Clear();
                foreach (var m in movies)
                {
                    Items.Add(m);
                    size++;
                }

                Title = size + " Results";

            }
            catch (Exception e)
            {
                Debug.Write(e);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
