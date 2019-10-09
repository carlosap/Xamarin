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
            HeadLine retVal = null;
            if (!string.IsNullOrWhiteSpace(sourcename))
            {
                var url = $"https://newsapi.org/v2/top-headlines?sources={sourcename}&apiKey=4e6dbf3545f6414581c52f4c0d18c142";
                var httpClient = new HttpClient();
                var json = await httpClient.GetStringAsync(url);
                retVal = JsonConvert.DeserializeObject<HeadLine>(json);
            }

            return await Task.FromResult(retVal);
        }
    }
}
