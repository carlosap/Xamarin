using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace QuoteApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new QuoteApp.MainPage();
            //MainPage = new StackLayoutLogin();
            //MainPage = new StackLayoutImage();
            //MainPage = new GridCalculator();
            //MainPage = new GridLogin();
            //MainPage = new AbsoluteLayoutAddCredit();
            //MainPage = new AbsoluteLayoutFooter();
            MainPage = new RelativeLayoutAddCredit();

        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
