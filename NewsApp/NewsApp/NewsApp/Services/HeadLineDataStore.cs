using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using NewsApp.Models;
using Newtonsoft.Json;
namespace NewsApp.Services
{
    public class HeadLineDataStore: IHeadLineDataStore
    {

        public async Task<HeadLine> GetNewsBySourceNameAsync(string sourcename)
        {
            var retVal = new HeadLine { Articles = sourcename == "cnn" ? GetCnnArticles() : GetCnbcArticles() };

            /*EXAMPLE CODE YOU CAN USE WITH YOUR OWN KEY*/
            //var url = $"https://newsapi.org/v2/top-headlines?sources={sourcename}&apiKey=<useyourkey>";
            //var httpClient = new HttpClient();
            //var json = await httpClient.GetStringAsync(url);
            //retVal = JsonConvert.DeserializeObject<HeadLine>(json);
            


            return await Task.FromResult(retVal);
        }

        private static List<Article> GetCnbcArticles()
        {
            return new List<Article>
            {
                new Article
                {
                    Author = "Annie Palmer",
                    Title = "Roku surges after analyst predicts it will triple its user base by 2022",
                    Description = "The analyst call on Roku also sent shares of Netflix down.",
                    Url = "https://www.cnbc.com/2019/10/09/roku-surges-after-analyst-predicts-it-will-triple-its-user-base-by-2022.html",
                    UrlToImage = "https://image.cnbcfm.com/api/v1/image/104741114-RTS1E9YN.jpg?v=1531837526",
                    Content = "Shares of Roku jumped 9% on Wednesday after Macquarie predicted the company could experience Netflix-like growth overseas. Netflix shares slid 1.1% following the report. \r\nRoku stands to triple its user base in the next three years"
                },
                new Article
                {
                    Author = "NBC News",
                    Title = "Sanders says he 'misspoke' about scaling back rallies after heart attack, vows 'vigorous' 2020 campaign",
                    Description = "Sanders also pushed back at criticism that his campaign was not transparent about his health, saying the campaign \"acted appropriately\" before disclosing he had a heart attack.",
                    Url = "https://www.cnbc.com/2019/10/09/sanders-says-he-misspoke-about-scaling-back-rallies-after-heart-attack.html",
                    UrlToImage = "https://image.cnbcfm.com/api/v1/image/106079157-1565807376903rts2m36t.jpg?v=1565807453",
                    Content = "Sen. Bernie Sanders on Wednesday tamped down on speculation that he would slow his presidential campaign after he suffered a heart attack last week"
                },
                new Article
                {
                    Author = "Yun Li",
                    Title = "China reportedly lowers expectations for progress on trade talks this week after US blacklist",
                    Description = "China has lowered its expectations for a trade deal after the White House blacklisted a slew of Chinese tech companies, Reuters reported.",
                    Url = "https://www.cnbc.com/2019/10/09/china-reportedly-lowers-expectations-for-progress-on-trade-this-week-after-us-blacklist.html",
                    UrlToImage = "https://image.cnbcfm.com/api/v1/image/105954990-1559914954452rtx6ybyj.jpg?v=1565195788",
                    Content = "China has lowered its expectations for progress on trade talks this week after the White House blacklisted a slew of Chinese tech companies over human rights violations, Reuters reported"
                },
                new Article
                {
                    Author = "Jeff Cox",
                    Title = "Market may be expecting more rate cuts than the Fed will deliver, meeting minutes show",
                    Description =
                        "The Fed's meeting minutes also showed that the trade war dragging down the economy was an overriding concern.",
                    Url = "https://www.cnbc.com/2019/10/09/fed-minutes.html",
                    UrlToImage = "https://image.cnbcfm.com/api/v1/image/106051957-1564611298676powell6.jpg?v=1564611316",
                    Content = "Some Federal Reserve policymakers expressed concern at their most recent meeting that markets are expecting more rate cuts than the central bank intends to deliver, according to minutes released Wednesday."
                },
            };
        }

        private static List<Article> GetCnnArticles()
        {
            return new List<Article>
            {
                new Article
                {
                    Author = "Alaa Elassar, CNN",
                    Title = "Who are the Kurds and why are they under attack?",
                    Description =
                        "Hundreds of people living in northern Syria near the Turkish border are fleeing, herding their loved ones and running from an unknown fate as fires blaze behind them.",
                    Url = "http://us.cnn.com/2019/10/09/world/kurds-in-syria-explainer-trnd/index.html",
                    UrlToImage =
                        "https://cdn.cnn.com/cnnnext/dam/assets/191009144627-09-turkey-syria-offensive-1009-super-tease.jpg",
                    Content = null
                },
                new Article
                {
                    Author = null,
                    Title = "Civilian Kurds in Syria tell CNN they don't know where it's safe - CNN Video",
                    Description =
                        "CNN's Clarissa Ward reports from Northern Syria as Turkey conducts military operations against US-backed Kurdish forces in the region.",
                    Url = "http://us.cnn.com/videos/world/2019/10/09/syria-turkey-kurds-offensive-ward-crn-vpx.cnn",
                    UrlToImage =
                        "https://cdn.cnn.com/cnnnext/dam/assets/191009133211-fleeing-kurdish-civilians-2-super-tease.jpg",
                    Content = "Chat with us in Facebook Messenger. Find out what's happening in the world as it unfolds."
                },
                new Article
                {
                    Author = "Helen Regan and Bianca Britton, CNN",
                    Title = "Turkey launches offensive in Syria against US-backed militia",
                    Description =
                        "Turkey began a planned military offensive into northeastern Syria on Wednesday, launching airstrikes and artillery fire across the border just days after the Trump administration announced it was pulling US troops back from the area.",
                    Url = "http://us.cnn.com/2019/10/09/politics/syria-turkey-invasion-intl-hnk/index.html",
                    UrlToImage = "https://cdn.cnn.com/cnnnext/dam/assets/191008081721-02-syria-border-1008-super-tease.jpg",
                    Content =
                        "(CNN)Turkey began a planned military offensive into northeastern Syria on Wednesday, launching airstrikes and artillery fire across the border just days after the Trump administration announced it was pulling US troops back from the area. \r\nThe operation is a… [+8257 chars]"
                },
                new Article
                {
                    Author = null,
                    Title = "Lindsey Graham criticizes Trump over Syria situation - CNN Video",
                    Description =
                        "Sen. Lindsey Graham (R-SC) criticized President Trump on Twitter for withdrawing US troops from northern Syria, which was followed by a Turkish military offensive.",
                    Url = "https://www.cnn.com/videos/politics/2019/10/09/lindsey-graham-trump-troops-syria-turkey-nr-vpx.cnn",
                    UrlToImage = "https://cdn.cnn.com/cnnnext/dam/assets/181221111123-lindsey-graham-12202018-super-tease.jpg",
                    Content = "Chat with us in Facebook Messenger. Find out what's happening in the world as it unfolds."
                },
                new Article
                {
                    Author = "Oliver Darcy, CNN Business",
                    Title = "Matt Drudge, an influential figure in conservative media, sours on Trump as he faces impeachment",
                    Description =
                        "President Donald Trump, facing an ever-deepening scandal that threatens to swallow his presidency, appears to have lost a key ally in conservative media: The Drudge Report.",
                    Url = "http://us.cnn.com/2019/10/09/media/matt-drudge-trump-impeachment/index.html",
                    UrlToImage =
                        "https://cdn.cnn.com/cnnnext/dam/assets/191008165417-01-donald-trump-matt-drudge-split-super-tease.jpg",
                    Content =
                        "New York (CNN Business)President Donald Trump, facing an ever-deepening scandal that threatens to swallow his presidency, appears to have lost a key ally in conservative media: The Drudge Report.\r\nThe narrative-setting news aggregation website, founded in 199… [+6601 chars]"
                }
            };
        }
    }
}
