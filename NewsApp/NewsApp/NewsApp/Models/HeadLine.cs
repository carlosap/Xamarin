using System.Collections.Generic;

namespace NewsApp.Models
{

    public class HeadLine
    {
        public string Title { get; set; }
        public string Status { get; set; }
        public int TotalResults { get; set; }
        public List<Article> Articles { get; set; }
    }
}