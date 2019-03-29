using Adriel.TheMovieDB.Domain.Entities;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Adriel.TheMovieDB.Domain
{
    public class MovieDB : IDisposable
    {
        private readonly HttpClient _client = new HttpClient();
        private const string _apiKey = "api_key=0961f4c7add80bfa5712f9c620c0dec5";

        public async Task<SearchObject> Search(string text)
        {
            try
            {
                var uri = $"https://api.themoviedb.org/3/search/movie?{_apiKey}&language=pt-BR&query={text}";

                var request = (HttpWebRequest)WebRequest.Create(uri);
                request.Accept = "application/json";

                var sb = new StringBuilder();
                var response = (HttpWebResponse)request.GetResponse();

                using (var sr = new StreamReader(response.GetResponseStream()))
                    sb.Append(sr.ReadToEnd());

                var res = sb.ToString();

                var result = JsonConvert.DeserializeObject<SearchObject>(res.Trim());
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<MovieDetails> GetMovieDetails(long id)
        {
            try
            {
                var uri = $"https://api.themoviedb.org/3/movie/{id}?{_apiKey}&language=pt-BR";

                var request = (HttpWebRequest)WebRequest.Create(uri);
                request.Accept = "application/json";

                var sb = new StringBuilder();
                var response = (HttpWebResponse)request.GetResponse();

                using (var sr = new StreamReader(response.GetResponseStream()))
                    sb.Append(sr.ReadToEnd());

                var res = sb.ToString();

                var result = JsonConvert.DeserializeObject<MovieDetails>(res.Trim());
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<DiscoverObject> DiscoverMovieWithReleaseDateGreaterOneYear()
        {
            try
            {
                var date = DateTime.Now.AddDays(-365).ToString("yyyy-MM-dd");
                var uri = $"https://api.themoviedb.org/3/discover/movie?{_apiKey}&language=pt-BR&sort_by=popularity.desc&include_adult=false&include_video=false&page=1&release_date.gte={date}";

                var request = (HttpWebRequest)WebRequest.Create(uri);
                request.Accept = "application/json";

                var sb = new StringBuilder();
                var response = (HttpWebResponse)request.GetResponse();

                using (var sr = new StreamReader(response.GetResponseStream()))
                    sb.Append(sr.ReadToEnd());

                var res = sb.ToString();

                var result = JsonConvert.DeserializeObject<DiscoverObject>(res.Trim());
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Dispose()
        {
            _client.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
