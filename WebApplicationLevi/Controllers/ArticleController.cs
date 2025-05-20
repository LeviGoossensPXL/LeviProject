using ClassLibraryLevi.Business;
using ClassLibraryLevi.Business.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplicationLevi.Models;

namespace WebApplicationLevi.Controllers
{
    [Route("api/[controller]"), ApiController]
    public class ArticleController : ControllerBase
    {
        [HttpGet]
        public ActionResult GetArticle()
        {
            var list = Articles.GetAllArticles(out string message);
            if (list is null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, message);
            }
            if (!list.Any())
            {
                return StatusCode(StatusCodes.Status404NotFound, message);
            }

            return StatusCode(StatusCodes.Status200OK, new {Articles = list, Message = message});
        }

        [HttpPost]
        public ActionResult PostArticle([FromBody] PostArticleModel postArticle)
        {
            Article? article = new Article(
                postArticle.Title,
                postArticle.Content,
                postArticle.PublishedTime,
                postArticle.AuthorName,
                postArticle.Category);
            article = Articles.AddArticle(article, out string message);
            if (article is null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, message);
            }

            return StatusCode(StatusCodes.Status201Created, new { Article = article, Message = message });
        }
    }
}
