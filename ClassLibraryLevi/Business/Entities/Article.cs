using ClassLibraryLevi.helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryLevi.Business.Entities
{
    // my data model for article
    public class Article
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime PublishedTime { get; set; }
        public string AuthorName { get; set; }
        public Category Category { get; set; }

        public Article(string title, string content)
        {
            Id = 0;
            Title = title;
            Content = content;
            PublishedTime = DateTime.Now;
            AuthorName = "Unknown";
            Category = Category.General;
        }

        public Article(string title, string content, DateTime publishedTime, string authorName, Category category)
        {
            Id = 0;
            Title = title;
            Content = content;
            PublishedTime = publishedTime;
            AuthorName = authorName;
            Category = category;
        }

        //use data row to fill article object
        public static Article FromDataRow(DataRow dataRowArticle)
        {
            return new Article((string)dataRowArticle["Title"], (string)dataRowArticle["Content"], (DateTime)dataRowArticle["PublishedTime"], (string)dataRowArticle["AuthorName"], (Category)Enum.Parse(typeof(Category), (string)dataRowArticle["Category"]))
            {
                Id = (int)dataRowArticle["Id"],
            };
        }
    }
}
