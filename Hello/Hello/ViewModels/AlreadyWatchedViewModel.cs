using Hello.Helpers;
using Hello.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Hello.ViewModels
{
    class AlreadyWatchedViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Movie> Items { get; set; } = new ObservableCollection<Movie>();

        public AlreadyWatchedViewModel()
        {
            ImdbApiTest();
        }

        async void ImdbApiTest() {
            LocalStorage localStorage = new LocalStorage();

            var local_list = await localStorage.GetItemsAsync();

            foreach (var ll in local_list)
            {
                System.Diagnostics.Debug.Write("onSecond | " + ll.Title);
                Items.Add(ll);
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
