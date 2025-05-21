using ClassLibraryLevi.Business.Entities;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppLevi
{
    internal class RestService
    {
        HttpClient _client = new HttpClient();
        private const string REST_URL = "https://h9z33q0b-7220.euw.devtunnels.ms/api/";

        public List<ArticleGetModel> Items;
        public RestService()
        {
            _client.BaseAddress = new Uri(REST_URL);
        }

        public void UpdateArticleList()
        {
            var httpResponseMessage = _client.GetAsync("Article");
            httpResponseMessage.Wait();
            var jsonContent = httpResponseMessage.Result.Content.ReadAsStringAsync();
            jsonContent.Wait();
            var data = (JObject)JsonConvert.DeserializeObject(jsonContent.Result);

            Items = JsonConvert.DeserializeObject<List<ArticleGetModel>>(data.GetValue("articles").ToString());
        }
    }
}
