using CatalogApi.Contracts;
using CatalogApi.Models;
using CatalogApi.Models.ConfigModels;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogApi.Services
{
    public class MoviesServiceMock : IMoviesService
    {

        static List<Movie> _list;
        private readonly MockSetting _setting;

        public MoviesServiceMock(IOptions<MockSetting> mockOptions) {
            _setting = mockOptions.Value;
        }

        public async Task<List<Movie>> GetAll()
        {
            await Task.Delay(_setting.Delay);
            return _list;
        }

        public async Task<Movie> AddMovie(Movie movie)
        {
            await Task.Delay(2000);
            var m = movie with { ID = _list.Last().ID + 1 };
            _list.Add(m);
            return m;
        }

        public async Task<Movie> DeleteMovie(int movieId)
        {
            await Task.Delay(2000);
            var movieToDelete = _list.Find(x => x.ID == movieId);
            if (movieToDelete != null)
            {
                _list.Remove(movieToDelete);
                return movieToDelete;
            }
            else
            {
                throw new InvalidOperationException("item cannot be found");
            }
        }

        public async Task<Movie> UpdateMovie(Movie movie)
        {
            await Task.Delay(2000);
            var movieToUpdateIndex = _list.FindIndex(x => x.ID == movie.ID);
            if (movieToUpdateIndex != -1)
            {
                var updatedMovie = _list[movieToUpdateIndex] with { Name = movie.Name, URL = movie.URL };
                _list[movieToUpdateIndex] = updatedMovie;
                return updatedMovie;
            }
            else
            {
                throw new InvalidOperationException("item cannot be found");
            }

        }

        public async Task<Movie> GetById(int movieId)
        {
            await Task.Delay(2000);
            var movieToUpdateIndex = _list.FindIndex(x => x.ID == movieId);
            if (movieToUpdateIndex != -1)
            {
                return _list[movieToUpdateIndex];
            }
            else
            {
                throw new InvalidOperationException("item cannot be found");
            }
        }


        static MoviesServiceMock()
        {
            _list = new List<Movie> {
                new Movie (1, "Star Wars 1", "http://localhost:7040/api/stream-video/Star Wars 1"),
                new Movie (2, "Star Wars 2", "http://localhost:7040/api/stream-video/Star Wars 2"),
                new Movie (2, "Star Wars 3", "http://localhost:7040/api/stream-video/Star Wars 3"),
                new Movie (2, "Star Wars 4", "http://localhost:7040/api/stream-video/Star Wars 4")
            };
        }
    }
}
