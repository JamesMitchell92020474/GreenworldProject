using System;
using System.Collections.Generic;
using GWApp.ViewModels;
using GWApp.Views;
using Xamarin.Forms;

namespace GWApp
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
