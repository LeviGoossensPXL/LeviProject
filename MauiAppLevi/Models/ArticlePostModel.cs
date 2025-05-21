namespace MauiAppLevi.Models
{
    class ArticlePostModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime PublishedTime { get; set; }
        public string AuthorName { get; set; }
        public Category Category { get; set; }
    }
}
