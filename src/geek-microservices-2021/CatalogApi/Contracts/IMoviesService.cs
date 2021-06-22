using CatalogApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogApi.Contracts
{
    public interface IMoviesService
    {
        Task<Movie> AddMovie(Movie movie);
        Task<Movie> DeleteMovie(int movieId);
        Task<List<Movie>> GetAll();
        Task<Movie> GetById(int movieId);
        Task<Movie> UpdateMovie(Movie movie);
    }
}
