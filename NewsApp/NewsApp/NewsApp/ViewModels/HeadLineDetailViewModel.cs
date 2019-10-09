using System;
using System.Collections.Generic;
using System.Text;
using NewsApp.Models;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;

namespace NewsApp.ViewModels
{
    public class HeadLineDetailViewModel : BaseViewModel
    {
        //Binding Objects- Data
        public ImageSource ImageSource { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }

        //Visible UI Components
        public bool IsImage { get; set; }
        public bool IsTitle { get; set; }
        public bool IsAuthor { get; set; }
        public bool IsDescription { get; set; }
        public bool IsUrl { get; set; }


        public HeadLineDetailViewModel(Article article = null)
        {
           

            if (article != null)
            {
                // Image
                if (!string.IsNullOrWhiteSpace(article.UrlToImage))
                {
                    var uri = new Uri(article.UrlToImage);
                    ImageSource = new UriImageSource
                    {
                        Uri = uri,
                        CachingEnabled = true,
                        CacheValidity = new TimeSpan(0, 1, 0, 0)
                    };

                    IsImage = true;
                }

                // Title
                if (article.Title != null)
                {
                    Title = article.Title;
                    IsTitle = true;
                }

                // Author
                if (article.Author != null)
                {
                    Author = article.Author;
                    IsAuthor = true;
                }

                // Description
                if (!string.IsNullOrWhiteSpace(article.Description))
                {
                    Description = article.Description;
                    IsDescription = true;

                }

                // Url
                if (!string.IsNullOrWhiteSpace(article.Url))
                {
                    Url = article.Url;
                    IsUrl = true;
                }


            }
        }
    }
}


