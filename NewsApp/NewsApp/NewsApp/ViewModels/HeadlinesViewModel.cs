using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using NewsApp.Models;
using Xamarin.Forms;

namespace NewsApp.ViewModels
{
    public class HeadlinesViewModel : BaseViewModel
    {
        public ObservableCollection<Article> Articles { get; set; }
        public Command LoadArticlesCommand { get; set; }
        public string LastUpdateDate { get; set; }

        public HeadlinesViewModel(HeadLine headLine = null)
        {
            Title = $"{headLine?.Title} News";
            LastUpdateDate = DateTime.Now.ToString();
            Articles = new ObservableCollection<Article>();
            LoadArticlesCommand = new Command(async () => await ExecuteLoadArticlesCommand(headLine.Title.ToLower()));
        }

        async Task ExecuteLoadArticlesCommand(string sourcename)
        {
            //pattern use to protect async functions
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {

                Articles.Clear();
                var headLineBy = await HeadLineDataStore.GetNewsBySourceNameAsync(sourcename);
                if (headLineBy != null && headLineBy.Articles != null)
                {
                    foreach (var item in headLineBy.Articles)
                        Articles.Add(item);
                }

                
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
