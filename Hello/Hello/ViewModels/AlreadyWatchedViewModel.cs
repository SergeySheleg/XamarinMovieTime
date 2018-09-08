﻿using Hello.Helpers;
using Hello.Models;
using Hello.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Hello.ViewModels
{
    class AlreadyWatchedViewModel : INotifyPropertyChanged
    {
        private IDataStore<Movie> LocalDataStorege = AlreadyWatchedMoviesLocalDataStore.getInstance();

        public ObservableCollection<Movie> Items { get; set; } = new ObservableCollection<Movie>();

        public AlreadyWatchedViewModel() {
            LoadFromLocalDataStorege();
        }
   
        private async void LoadFromLocalDataStorege()
        {
            var storedMovies = await LocalDataStorege.GetItemsAsync();

            foreach (var m in storedMovies)
            {
                Items.Add(m);
                System.Diagnostics.Debug.Write("ITEMS: " + m.Title);
            }
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}