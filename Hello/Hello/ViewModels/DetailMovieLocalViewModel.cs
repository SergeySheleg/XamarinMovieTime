using Hello.Models;
using Hello.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Hello.ViewModels
{
    public class DetailMovieLocalViewModel : BaseViewModel
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


        public DetailMovieLocalViewModel(Movie movie)
        {
            Movie = movie;
            Title = movie.Title;
        }
        
        public async void AddToWantToWatch()
        {
            await WantToWatchMoviesLocalDataStore.Current.AddItemAsync(movie);
        }

        public async void AddToAlreadyWatch()
        {
            await AlreadyWatchedMoviesLocalDataStore.Current.AddItemAsync(movie);
        }

        public async void MoveToWantToWatch()
        {
            try
            {
                await AlreadyWatchedMoviesLocalDataStore.Current.DeleteItemAsync(movie);
                await WantToWatchMoviesLocalDataStore.Current.AddItemAsync(movie);
            }
            catch (Exception e) {
                Debug.Write(e);
            }

        }

        public async void MoveToAlreadyWatch()
        {
            try 
            {
                await WantToWatchMoviesLocalDataStore.Current.DeleteItemAsync(movie);
                await AlreadyWatchedMoviesLocalDataStore.Current.AddItemAsync(movie);
            }
            catch (Exception e)
            {
                Debug.Write(e);
            }
        }

        public async void RemoveFromWantToWatch()
        {
            try
            {
                await WantToWatchMoviesLocalDataStore.Current.DeleteItemAsync(movie);
            }
            catch (Exception e) {
                Debug.Write(e);
            }

        }

        public async void RemoveFromAlreadyWatch()
        {
            try
            {
                await AlreadyWatchedMoviesLocalDataStore.Current.DeleteItemAsync(movie);
            }
            catch (Exception e)
            {
                Debug.Write(e);
            }
        }
    }
}
