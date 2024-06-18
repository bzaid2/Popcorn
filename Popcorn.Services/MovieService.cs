using System;
using System.Net.Http;
using System.Threading.Tasks;
using Popcorn.Interfaces;
using Popcorn.Models.ReponseDto;

namespace Popcorn.Services
{
    public class MovieService : IMovie
    {
        private Group selectedMovie;
        private const string BASE_URL = "https://api.jsonbin.io";

        private static readonly HttpClient client = new HttpClient();

        private readonly IJson jsonService;
        private readonly ILoggerManager loggerService;

        public Group SelectedMovie { get => selectedMovie; set => selectedMovie = value; }

        public MovieService(
            IJson _jsonService,
            ILoggerManager _loggerService)
        {
            client.BaseAddress = new Uri(BASE_URL);
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            jsonService = _jsonService;
            loggerService = _loggerService;
        }

        public async Task<Root> GetListOfMoviesByPageAsync(int page)
        {
            try
            {
                string url = "/v3/b/";
                switch(page)
                {
                    case 1:
                        url += "6670b55be41b4d34e404c04d";
                        break;
                    case 2:
                        url += "6670b55be41b4d34e404c04d";
                        break;
                    case 3:
                        url += "6670b67cad19ca34f87a78ed";
                        break;
                    case 4:
                        url += "6670b6abe41b4d34e404c0bd";
                        break;
                    case 5:
                        url += "6670b786e41b4d34e404c0f0";
                        break;
                }
                var result = await client.GetAsync(url);
                string contenString = await result.Content.ReadAsStringAsync();
                return jsonService.Deserialize<Root>(contenString);
            } catch(Exception ex)
            {
                loggerService.Error("Ocurrió un error al recuperar la lista de peliculas", ex);
                return null;
            }
        }
    }
}
