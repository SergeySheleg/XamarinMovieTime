using Hello.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Hello.Services
{
    class AlreadyWatchedMoviesLocalDataStore : MoviesLocalDataStore
    {
        public static readonly AlreadyWatchedMoviesLocalDataStore Current = new AlreadyWatchedMoviesLocalDataStore();
        
        private AlreadyWatchedMoviesLocalDataStore() : base("AlreadyWatchedMovies.db3")
        {
        }

        public new Task<int> AddItemAsync(Movie item)
        {
            var r = database.InsertAsync(item);
            r.ContinueWith((i) =>
            {
                MessagingCenter.Send(this, "AddItem", item);
            });

            return r;

            }
        }
}
