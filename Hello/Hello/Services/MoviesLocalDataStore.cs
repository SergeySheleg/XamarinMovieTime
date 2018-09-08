using Hello.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Hello.Services
{
    class MoviesLocalDataStore : IDataStore<Movie>
    {
        protected SQLiteAsyncConnection database;
        public MoviesLocalDataStore(string dataBaseName)
        {
            database = new SQLiteAsyncConnection(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), dataBaseName));
            database.CreateTableAsync<Movie>()/*.Wait()*/;
        }

        public Task<int> AddItemAsync(Movie item)
        {
            return database.InsertAsync(item);
        }

        public Task<Movie> GetItemAsync(string id)
        {
            return database.GetAsync<Movie>(id);
        }

        public Task<int> DeleteItemAsync(string id)
        {
            return database.DeleteAsync(GetItemAsync(id));
        }
        
        public Task<List<Movie>> GetItemsAsync(bool forceRefresh = false)
        {
            if (forceRefresh)
                throw new NotImplementedException();
            
            return database.Table<Movie>().ToListAsync();
        }

        public Task<int> UpdateItemAsync(Movie item)
        {
            return database.InsertOrReplaceAsync(item);
        }

        public Task<int> EraseAllAsync()
        {
            return database.DropTableAsync<Movie>();
        }
    }
}
