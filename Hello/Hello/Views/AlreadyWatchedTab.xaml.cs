﻿using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Hello.ViewModels;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


using System.Net.Http;

namespace Hello.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AlreadyWatchedTab : ContentPage
    {
        AlreadyWatchedViewModel viewModel = new AlreadyWatchedViewModel();
        public AlreadyWatchedTab()
        {
            InitializeComponent();
            BindingContext = viewModel;
            startInitViewModelAsync();
        }

        async void startInitViewModelAsync()
        {
            await viewModel.InitAsync();
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            await DisplayAlert("Item Tapped", "An item was tapped.", "OK");

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }
    
    }
}
