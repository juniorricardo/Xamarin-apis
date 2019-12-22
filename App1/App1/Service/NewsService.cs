using NewsAPI;
using System;
using System.Collections.Generic;
using System.Text;
using AppDemo.Entities;
using System.Threading.Tasks;
using System.Diagnostics;
using NewsAPI.Models;
using NewsAPI.Constants;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;

namespace AppDemo.Service
{
    public class NewsService
    {
        HttpClient _client;
        public NewsService()
        {
            _client = new HttpClient();
        }
        public async Task<NewsPOJO> getNews(string query)
        {
            NewsPOJO listNoticias = null;
            try
            {
                var response = await _client.GetAsync(query);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    listNoticias = JsonConvert.DeserializeObject<NewsPOJO>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\t\tERROR {0}", ex.Message);
            }
            return listNoticias;
        }

    }
}
