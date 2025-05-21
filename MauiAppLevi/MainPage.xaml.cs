using System.Text.Json;
using ClassLibraryLevi.Business.Entities;
using MauiAppLevi.Models;

namespace MauiAppLevi
{
    public partial class MainPage : ContentPage
    {
        RestService _restService = new();
        public MainPage()
        {
            InitializeComponent();
        }

        private void OnLoadBtnClick(object sender, EventArgs e)
        {
            _restService.UpdateArticleList();
            ListView.ItemsSource = _restService.Items;
            //_restService.PostArticle(new ArticlePostModel
            //{
            //    Title = "Test",
            //    Content = "Test",
            //    PublishedTime = DateTime.Now,
            //    AuthorName = "Test",
            //    Category = Category.General
            //});
        }
    }

}
