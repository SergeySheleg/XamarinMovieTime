using Hello.Models;
using Hello.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hello.ViewModels
{
    public class DetailMovieSearchViewModel : BaseViewModel
    {

        private Movie movie;
        public Movie Movie
        {
            get
            {
                return movie;
            }
            set
            {
                SetProperty(ref movie, value);
            }
        }
        
        public DetailMovieSearchViewModel(Movie movie, bool downloadFull = true)
        {
            Movie = movie;
            Title = movie.Title;
            if (downloadFull)
            {
                getDetail();
            }

        }

        public async void getDetail()
        {
            var m = await new IMDBDataProvider().GetMovieByIdAsync(Movie.imdbID);
            Movie = m;
        }

        public async void AddToWantToWatch()
        {
            await WantToWatchMoviesLocalDataStore.Current.AddItemAsync(movie);
        }

        public async void AddToAlreadyWatch()
        {
            await AlreadyWatchedMoviesLocalDataStore.Current.AddItemAsync(movie);
        }
    }
}
