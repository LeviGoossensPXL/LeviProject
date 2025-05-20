using System.Text.Json;
using ClassLibraryLevi.Business.Entities;

namespace MauiAppLevi
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;
            ListView.ItemsSource = new List<Article>
            {
                new Article("Title 1", "Content 1"),
                new Article("Title 2", "Content 2"),
                new Article("Title 3", "Content 3"),
            };
        }
    }

}
