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
        }
    }

}
