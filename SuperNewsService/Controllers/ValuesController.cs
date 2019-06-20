using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SuperNewsService.NewsFacade.Implementation;
using SuperNewsService.NewsFacade.Contracts;
using SuperNewsService.NewsFacade.Contracts.Models;

namespace SuperNewsService.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly INewsInterface news;
        public ValuesController()
        {
            news = new NewsImplementation();
        }
        // GET api/values
        [HttpGet]
        public async Task<IActionResult> Get(string queryItem, string market, string freshness, string preferences)
        {
            var response = await news.GetPolarNews(queryItem, market, freshness, preferences);

            return new OkObjectResult(response);
        }
    }
}
