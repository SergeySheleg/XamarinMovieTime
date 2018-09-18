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
        public ObservableCollection<Movie> Items { get; set; }
        private OMDBDataProvider omdb = new OMDBDataProvider();

        public SearchMoviesViewModel()
        {
            Items = omdb.Items;
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
                await omdb.SearchMoviesByNameAsync(MovieName);
                Title = Items.Count + " Results";

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
