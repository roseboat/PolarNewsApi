using System;
using System.Collections.Generic;
using System.Text;

namespace SuperNewsService.NewsFacade.Contracts.Models
{
    public class Newsitem
    {
        public String SourceID { get; set; }
        public String SourceName { get; set; }
        public String Title { get; set; }
        public String Description { get; set; }
        public DateTime PublishedDate { get; set; }


    }
}
