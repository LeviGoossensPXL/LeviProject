using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppLevi
{
    class ArticleGetModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime PublishedTime { get; set; }
        public string AuthorName { get; set; }
        public Category Category { get; set; }
    }

    public enum Category
    {
        General,
        Science,
        Politics,
        Technology,
        Sports,
        Entertainment
    }
}
