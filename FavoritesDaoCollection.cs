using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Cognizant.MovieCruiser.Model;

namespace Com.Cognizant.MovieCruiser.DAO
{
    public class FavoritesDaoCollection : IFavoriteDao
    {
        Dictionary<long, Favorites> _userFavorites;
        public FavoritesDaoCollection()
        {
            if (_userFavorites == null)
            {
                _userFavorites = new Dictionary<long, Favorites>();
                _userFavorites.Add(1, new Favorites(new List<MovieList>()
        {
          new MovieList(1, "Lord of the Rings", 1299.87f, true, DateTime.ParseExact("15/11/2019","dd/MM/yyyy", null), "Action", true),
          new MovieList(2, "Avengers", 5126.89f, true, DateTime.ParseExact("23/12/2019","dd/MM/yyyy", null), "Action", true),
          new MovieList(3, "Interstellar", 2451.66f, true, DateTime.ParseExact("12/10/2018","dd/MM/yyyy", null), "Science", false)
        }));
                _userFavorites.Add(2, new Favorites(new List<MovieList>()
        {
          new MovieList(1, "Lord of the Rings", 1299.87f, true, DateTime.ParseExact("15/11/2019","dd/MM/yyyy", null), "Action", true),
          new MovieList(5, "Final Destination", 5412.22f, true, DateTime.ParseExact("05/03/2019","dd/MM/yyyy", null), "Horror", true),
          new MovieList(6, "Batman Begins", 2654.87f, true, DateTime.ParseExact("15/03/2017","dd/MM/yyyy", null), "Action", true)
               }));
            }
        }

        public void AddFavoriteMovieList(long userId, long movieitemId)
        {
            MovieListDaoCollection MovieListDao = new MovieListDaoCollection();
            MovieList movieList = MovieListDao.GetMovieList(movieitemId);
            if (_userFavorites.ContainsKey(userId))
            {
                _userFavorites[userId].MovieList.Add(movieList);
                _userFavorites[userId].Count += movieList.Budget;
            }

            else
            {
                _userFavorites.Add(userId, new Favorites(new List<MovieList>() { movieList }));
            }
        }

        public Favorites GetAllFavoritesList(long userId)
        {
            if (_userFavorites.ContainsKey(userId))
            {
                return _userFavorites[userId];
            }
            else
            {
                throw new FavoritesEmptyException("Favorites is Empty");
            }
        }
        public void RemoveFavoriteMovie(long userId, long movieId)
        {
            if (_userFavorites.ContainsKey(userId))
            {
                var favToRemove = _userFavorites[userId].MovieList.FirstOrDefault(p => p.Id == movieId);
                _userFavorites[userId].Count -= favToRemove.Budget;
                _userFavorites[userId].MovieList.Remove(favToRemove);
            }
        }
    }
}
