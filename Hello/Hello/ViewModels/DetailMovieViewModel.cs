using Hello.Models;
using Hello.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hello.ViewModels
{
    public class DetailMovieViewModel : BaseViewModel
    {

        private Movie movie;
        public Movie Movie {
            get
            {
                return movie;
            }
            set
            {
                SetProperty(ref movie, value);
            }
        }
        
        public DetailMovieViewModel(Movie movie, bool downloadFull = true)
        {
            Movie = movie;
            if (downloadFull) {
                getDetail();
            }

        }

        public async void getDetail() {
            var m = await new IMDBDataProvider().GetMovieByIdAsync(Movie.imdbID);
            Movie = m;
        }

        public async void AddToWantToWatch() {
            
        }

        public async void AddToAlreadyWatch() {
            await AlreadyWatchedMoviesLocalDataStore.Current.AddItemAsync(movie);
        }
    }
}
