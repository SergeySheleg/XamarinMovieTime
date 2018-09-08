using System;
using System.Collections.Generic;
using System.Text;

namespace Hello.Services
{
    class WantToWatchMoviesLocalDataStore
    {
        private static MoviesLocalDataStore instance;
        private static object syncRoot = new Object();
        public static MoviesLocalDataStore getInstance() {
            if (instance == null) {
                lock (syncRoot)
                {
                    if (instance == null)
                        instance = new MoviesLocalDataStore("WantToWatchMovies.db3");
                }
            }
            return instance;
        }
    }
}
