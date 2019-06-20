using SuperNewsService.NewsFacade.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using SuperNewsService.NewsFacade.Contracts.Models;
using Microsoft.Azure.CognitiveServices.Search.NewsSearch;
using Microsoft.Azure.CognitiveServices.Search.NewsSearch.Models;
using System.Threading.Tasks;

namespace SuperNewsService.NewsFacade.Implementation
{
    public class NewsImplementation : INewsInterface
    {
        private readonly NewsSearchClient client;
        public NewsImplementation()
        {
            client = new NewsSearchClient(new ApiKeyServiceClientCredentials("4fa7760d760f43c193545adc6c28f4cc"));
            client.Endpoint = "https://api.cognitive.microsoft.com/";
        }

        private Dictionary<string, string> sources = new Dictionary<string, string> { { "BBC", "The Sun"}, { "CNN", "Fox" } };

        public async Task<List<Newsitem>> GetPolarNews(string query, string market, string freshness, string preferences)
        {
            try
            {
                var newsResult = await client.News.SearchAsync(query, market: market, freshness: freshness);

                var response = new List<Newsitem>();

                newsResult.Value.ToList().ForEach(item =>
                {
                    if (item.Provider.Any(provider => { if (sources.ContainsKey(preferences)) { return provider.Name == sources[preferences]; } else return false; }))
                    {
                        response.Add(new Newsitem()
                        {
                            Title = item.Name,
                            Description = item.Description,
                            PublishedDate = DateTime.Parse(item.DatePublished),
                            SourceName = item.Provider.FirstOrDefault()?.Name,
                        });
                    }
                }
                );

                return response;
            }
            catch(Exception ex)
            {
                return new List<Newsitem>();
            }
        }
    }
}
