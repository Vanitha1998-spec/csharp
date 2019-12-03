using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Cognizant.MovieCruiser.Model;

namespace Com.Cognizant.MovieCruiser.DAO
{
    public interface IFavoriteDao
    {
        void AddFavoriteMovieList(long userId, long movieitemId);
        Favorites GetAllFavoritesList(long userId);
        void RemoveFavoriteMovie(long userId, long movieId);
    }
}
