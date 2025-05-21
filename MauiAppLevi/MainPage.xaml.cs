using System.Text.Json;
using ClassLibraryLevi.Business.Entities;

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
        }
    }

}
