using Hello.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Hello.Helpers
{
    class LocalStorage
    {
        SQLiteAsyncConnection database;
        public LocalStorage(string name = "TestSQLite.db3") {
            database = new SQLiteAsyncConnection(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), name));

        }

        public void CreateTable()
        {
            database.CreateTableAsync<Movie>().Wait();
        }

        public Task<int> SaveItemAsync(Movie movie)
        {
            return database.InsertAsync(movie);
        }
        public Task<List<Movie>> GetItemsAsync()
        {
            return database.Table<Movie>().ToListAsync();
        }
        public void DropTable()
        {
            database.DropTableAsync<Movie>().Wait();
        }

    }
}
