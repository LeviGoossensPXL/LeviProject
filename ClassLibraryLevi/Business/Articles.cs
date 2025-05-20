using ClassLibraryLevi.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibraryLevi.Data.Framework;
using ClassLibraryLevi.Business.Entities;
using System.Data;

namespace ClassLibraryLevi.Business
{
    public static class Articles
    {
        public static IEnumerable<Article>? GetAllArticles(out string message)
        {
            ArticleData articleData = new ArticleData();
            SelectResult result = articleData.SelectAllArticles();
            if (!result.Succeeded)
            {
                message = "Fetching articles from database produced a error";
                return null;
            }
            List<Article> articles = new List<Article>();
            if (result.DataTable.Rows.Count == 0)
            {
                message = "No articles found";
                return articles;
            }
            result.DataTable.Rows.Cast<DataRow>().ToList().ForEach(row =>
            {
                articles.Add(Article.FromDataRow(row));
            });
            message = "Articles fetched successfully";
            return articles;
        }

        public static Article? AddArticle(Article article, out string message)
        {
            ArticleData articleData = new ArticleData();
            InsertResult result = articleData.InsertArticle(article);
            if (!result.Succeeded)
            {
                message = "Inserting article into database produced a error";
                return null;
            }
            article.Id = result.NewId;
            message = "Article inserted successfully";
            return article;
        }
    }
}
