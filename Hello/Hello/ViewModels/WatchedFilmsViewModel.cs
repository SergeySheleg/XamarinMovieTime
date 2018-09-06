using Hello.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Hello.ViewModels
{
    class WatchedFilmsViewModel : BaseViewModel
    {
        public ObservableCollection<Film> Items { get; set; } = new ObservableCollection<Film>();

        public WatchedFilmsViewModel()
        {
            Items.Add(new Film { Title = "Hello. Origin", Genre = "Action", Year = 1999, IMDBRating = 1.0, UserRating = 2.0, Image = new Xamarin.Forms.Image { Source = "drawable/xamarin_logo.png"} });
            Items.Add(new Film { Title = "Hello 2", Genre = "Action", Year = 1999, IMDBRating = 1.0, UserRating = 2.0 });
            Items.Add(new Film { Title = "Hello 3", Genre = "Action", Year = 1999, IMDBRating = 1.0, UserRating = 2.0 });
        }
    }
}
