using Hello.Models;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Hello.Services
{
    class WantToWatchMoviesLocalDataStore : MoviesLocalDataStore
    {
        public static readonly WantToWatchMoviesLocalDataStore Current = new WantToWatchMoviesLocalDataStore();

        private WantToWatchMoviesLocalDataStore() : base("WantToWatchMovies.db3")
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

        public new Task<int> DeleteItemAsync(Movie item)
        {
            var r = database.DeleteAsync(item);
            r.ContinueWith((i) =>
            {
                MessagingCenter.Send(this, "DeleteItem", item);
            });

            return r;
        }


    }
}
