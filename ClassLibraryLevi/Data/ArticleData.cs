using ClassLibraryLevi.Business.Entities;
using ClassLibraryLevi.Data.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace ClassLibraryLevi.Data
{
    internal class ArticleData : SqlServer
    {
        public override string TableName { get; } = "Articles";

        public SelectResult SelectAllArticles()
        {
            return SelectStatement();
        }
        
        public InsertResult InsertArticle(Article article)
        {
            try
            {
                StringBuilder insertQuery = new StringBuilder();
                insertQuery.Append($"INSERT INTO {TableName} ");
                insertQuery.Append("([Title],[Content],[PublishedTime],[AuthorName],[Category]) VALUES");
                insertQuery.Append(" (@Title, @Content, @PublishedTime, @AuthorName, @Category);");

                using SqlCommand insertCommand = new SqlCommand(insertQuery.ToString());
                
                SetAllParameters(article, insertCommand);

                return InsertStatement(insertCommand);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            
        }

        private void SetAllParameters(Article article, SqlCommand sqlCommand)
        {
            sqlCommand.Parameters.AddWithValue("@Title", article.Title);
            sqlCommand.Parameters.AddWithValue("@Content", article.Content);
            sqlCommand.Parameters.AddWithValue("@PublishedTime", article.PublishedTime);
            sqlCommand.Parameters.AddWithValue("@AuthorName", article.AuthorName);
            sqlCommand.Parameters.AddWithValue("@Category", article.Category.ToString());
        }
    }
}
