using NewsApp.Models;
using NewsApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NewsApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HeadLinesPage : ContentPage
    {
        HeadlinesViewModel viewModel;
        public HeadLinesPage(HeadlinesViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = this.viewModel = viewModel;
        }

        async void ItemsListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedArticle = e.SelectedItem as Article;
            if (selectedArticle == null)
                return;

            await Navigation.PushModalAsync(new NavigationPage(new HeadLineDetailPage(new HeadLineDetailViewModel(selectedArticle))),true);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (viewModel.Articles.Count == 0)
            {
                viewModel.LoadArticlesCommand.Execute(null);
            }
        }
    }
}