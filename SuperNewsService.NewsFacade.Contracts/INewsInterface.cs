
using SuperNewsService.NewsFacade.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SuperNewsService.NewsFacade.Contracts
{     
    public interface INewsInterface
    {
        Task<List<Newsitem>> GetPolarNews(string query, string market, string freshness, string preferences);
    }
}
