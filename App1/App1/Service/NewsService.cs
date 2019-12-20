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

namespace AppDemo.Service
{
    public class NewsService
    {
        NewsApiClient newsApiClient = new NewsApiClient("75b4f2ea8ca74bc9b1febdb90f2efd12");

        public List<NewsPOJO> getNews()
        {
            List<NewsPOJO> listNoticias = null;
            NewsPOJO noticia;
            try
            {
                /** newsapi.org/v2/top-headlines?country=ar&apiKey=75b4f2ea8ca74bc9b1febdb90f2efd12 * */
                var articlesResponse = newsApiClient.GetTopHeadlines(new TopHeadlinesRequest()
                {
                    Country = Countries.AR,
                    Category = Categories.Sports
                });
                //var articlesResponse = newsApiClient.GetEverything(new EverythingRequest
                //{
                //    Q = "Apple",
                //    SortBy = SortBys.Popularity,
                //    Language = Languages.EN,
                //    From = new DateTime(2018, 1, 25)
                //});
                if (articlesResponse.Status == Statuses.Ok)
                {
                    //Console.WriteLine(articlesResponse.TotalResults);

                    foreach (var article in articlesResponse.Articles)
                    {
                        noticia = new NewsPOJO()
                        {
                            title = article.Title,
                            author = article.Author,
                            description = article.Description,
                            url = article.Url,
                            urlToImage = article.UrlToImage,
                            publishedAt = Convert.ToDateTime(article.PublishedAt)
                        };
                        listNoticias.Add(noticia);
                    }
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
