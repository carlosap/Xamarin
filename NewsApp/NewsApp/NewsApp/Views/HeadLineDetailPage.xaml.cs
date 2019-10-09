using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewsApp.Models;
using NewsApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace NewsApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HeadLineDetailPage : ContentPage
    {
        HeadLineDetailViewModel viewModel;
        public HeadLineDetailPage(HeadLineDetailViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = this.viewModel = viewModel;
        }

        async void Done_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();

        }

        async void OpenUrl_OnClicked(object sender, EventArgs e)
        {
            string uri = ((Button) sender).BindingContext as string;
            if (!string.IsNullOrWhiteSpace(uri))
            {
                await Browser.OpenAsync(uri, new BrowserLaunchOptions
                {
                    LaunchMode = BrowserLaunchMode.SystemPreferred,
                    TitleMode = BrowserTitleMode.Show,
                    PreferredToolbarColor = Color.AliceBlue,
                    PreferredControlColor = Color.Violet
                });
            }

        }
    }
}