using System;
using System.ComponentModel;
using Xamarin.Forms;
using SpartanNote.ViewModels;

namespace SpartanNote.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class ItemDetailPage : ContentPage
    {
        ItemDetailViewModel viewModel;

        public ItemDetailPage(ItemDetailViewModel viewModel)
        {
            InitializeComponent();
            this.viewModel = viewModel;
            BindingContext = this.viewModel;
        }

        public ItemDetailPage()
        {
            InitializeComponent();
            viewModel = new ItemDetailViewModel();
            BindingContext = viewModel;
        }

        private void Cancel_Clicked(object sender, EventArgs e)
        {

            //Because you got here with a PushModalAsync (modal) you can close the Modal with a PoP
            Navigation.PopModalAsync();

        }

        private void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "SaveNote", viewModel.Note);
            Navigation.PopModalAsync();

        }
    }
}