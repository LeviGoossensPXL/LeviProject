using MauiAppLevi.Models;

namespace MauiAppLevi;

public partial class PostArticlePage : ContentPage
{
	public PostArticlePage()
	{
		InitializeComponent();
        categoryPicker.ItemsSource = Enum.GetNames(typeof(Category));

    }

    private void postArticleButton_Clicked(object sender, EventArgs e)
    {
        var articlePostModel = new ArticlePostModel
        {
            Title = titleEntry.Text,
            Content = contentEditor.Text,
            AuthorName = authorEntry.Text,
            PublishedTime = publishedDatePicker.Date,
            Category = (Category)Enum.Parse(typeof(Category), categoryPicker.SelectedItem.ToString())
        };
        // Post the article using the RestService
        var restService = new RestService();
        restService.PostArticle(articlePostModel);
        statusLabel.Text = "Article posted successfully!";
        statusLabel.Background = Colors.Green;
    }
}