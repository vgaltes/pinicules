﻿using Pinicules.Domain.DTOs;
using Pinicules.Domain.Repositories;
using System.Linq;
using TMDbLib.Client;
using TMDbLib.Objects.Movies;

namespace Pinicules.Infrastructure.Repositories
{
    public class TmdbRepository : ITmdbRepository
    {
        private string API_KEY = "16ccc0e8d1eb827495441b96b448b02f";
        TMDbClient client;

        public TmdbRepository()
        {
            client = new TMDbClient(API_KEY);
            client.GetConfig();
        }

        public MovieDTO GetMovieInformation(MovieDTO movieDto)
        {
            var sizes = client.Config.Images.PosterSizes;

            Movie movie = client.GetMovie(movieDto.Id, "ES", MovieMethods.Credits | MovieMethods.Images);

            movieDto.Summary = movie.Overview;
            movieDto.Title = movie.Title;
            movieDto.Directors = movie.Credits.Crew.Where(c => c.Job == "Director").Select(c => c.Name).ToList();
            movieDto.Actors = movie.Credits.Cast.Select(c => c.Name).ToList();
            movieDto.Image = client.GetImageUrl(sizes[3], movie.PosterPath).ToString();

            return movieDto;
        }

        public MovieDTO GetMovieInformation(int movieId)
        {
            Movie movie = client.GetMovie(movieId, "ES", MovieMethods.Credits | MovieMethods.Images);

            var sizes = client.Config.Images.PosterSizes;
            MovieDTO movieDto = new MovieDTO
            {
                Id = movieId,
                Summary = movie.Overview,
                Title = movie.Title,
                Directors = movie.Credits.Crew.Where(c => c.Job == "Director").Select(c => c.Name).ToList(),
                Actors = movie.Credits.Cast.Select(c => c.Name).ToList(),
                Image = client.GetImageUrl(sizes.Last(), movie.PosterPath).ToString()
            };

            return movieDto;
        }


        public System.Collections.Generic.List<MovieDTO> GetMovies(string searchTerm)
        {
            throw new System.NotImplementedException();
        }
    }
}
