using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewsApp.Models;
using NewsApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NewsApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
        }


        async void HandleCnn_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HeadLinesPage(new HeadlinesViewModel(new HeadLine { Title = "CNN" })));

        }

        async void HandleCNBC_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HeadLinesPage(new HeadlinesViewModel(new HeadLine { Title = "CNBC" })));

        }
    }
}