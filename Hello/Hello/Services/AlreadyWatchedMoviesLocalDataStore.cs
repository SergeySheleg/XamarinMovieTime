using Hello.Models;
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
        
        public  new Task<int> DeleteItemAsync(Movie item)
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
