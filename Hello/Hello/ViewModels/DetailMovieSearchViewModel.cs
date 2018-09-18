using Hello.Models;
using Hello.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        bool isWantToWatch = false;
        public bool IsWantToWatch
        {
            get { return isWantToWatch; }
            set { SetProperty(ref isWantToWatch, value); }
        }

        bool isAlreadyWatched = false;
        public bool IsAlreadyWatched
        {
            get { return isAlreadyWatched; }
            set { SetProperty(ref isAlreadyWatched, value); }
        }

        bool isNotInLocalStorage = true;
        public bool IsNotInLocalStorage
        {
            get { return isNotInLocalStorage; }
            set { SetProperty(ref isNotInLocalStorage, value); }
        }

        public DetailMovieSearchViewModel(Movie movie, bool downloadFull = true)
        {
            Movie = movie;
            checkContains();

            Title = movie.Title;
            if (downloadFull)
            {
                getDetail();
            }

        }

        public async void checkContains() {
            IsWantToWatch = await WantToWatchMoviesLocalDataStore.Current.CheckContainsAsync(movie);
            IsAlreadyWatched = await AlreadyWatchedMoviesLocalDataStore.Current.CheckContainsAsync(movie);
            IsNotInLocalStorage = !IsWantToWatch && !IsAlreadyWatched;

            Debug.Write(movie.Title + " IsWantToWatch = " + IsWantToWatch + " IsAlreadyWatched = " + IsAlreadyWatched);
            
        }

        public async void getDetail()
        {
            var m = await new OMDBDataProvider().GetMovieByIdAsync(Movie.imdbID);
            Movie = m;
        }

        public async void AddToWantToWatch()
        {
            try
            {
                await WantToWatchMoviesLocalDataStore.Current.AddItemAsync(movie);
            }
            catch (Exception e) {
                Debug.Write(e);
            }
        }

        public async void AddToAlreadyWatch()
        {
            try
            {
                await AlreadyWatchedMoviesLocalDataStore.Current.AddItemAsync(movie);
            }
            catch (Exception e) {
                Debug.Write(e);
            }
        }
    }
}
