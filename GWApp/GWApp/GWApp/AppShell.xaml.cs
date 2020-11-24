using System;
using System.Collections.Generic;
using GWApp.ViewModels;
using GWApp.Views;
using Xamarin.Forms;

[assembly: ExportFont("BebasNeue.ttf", Alias = "ThemeFont")]
[assembly: ExportFont("Roboto.ttf", Alias = "LightFont")]
namespace GWApp
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
        }

    }
}
