using Adriel.TheMovieDB.Domain.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Adriel.TheMovieDB.Domain
{
    public class MovieDB
    {
        private HttpClient _client = new HttpClient();
        private const string _apiKey = "api_key=0961f4c7add80bfa5712f9c620c0dec5";

        public async Task<SearchObject> Search(string text)
        {
            try
            {
                var uri = $"https://api.themoviedb.org/3/search/movie?{_apiKey}&query={text}";
                var response = await _client.GetStringAsync(uri);
                var result = JsonConvert.DeserializeObject<SearchObject>(response.Trim());
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
                var uri = $"https://api.themoviedb.org/3/movie/{id}?{_apiKey}";
                var response = await _client.GetStringAsync(uri);
                var result = JsonConvert.DeserializeObject<MovieDetails>(response.Trim());
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
