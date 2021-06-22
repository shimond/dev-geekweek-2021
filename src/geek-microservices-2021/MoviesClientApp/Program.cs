using MoviceServiceNS;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace MoviesClientApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            HttpClient client = new HttpClient();
            MovieClient movieClient = new MovieClient("http://localhost:5000", client);
            //movieClient.GetAllMoviesAsync
            //movieClient.DeleteMovieAsync
            var movies = await movieClient.GetAllMoviesAsync();
            foreach (var item in movies)
            {
                Console.WriteLine(item.Name);
            }

            Console.ReadLine();


            //var response = await client.GetAsync("http://localhost:5000/api/Movies");
            //if (response.IsSuccessStatusCode)
            //{
            //    var body = await response.Content.ReadAsStringAsync();
            //}
        }
    }
}
