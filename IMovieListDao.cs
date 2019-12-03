using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Cognizant.MovieCruiser.Model;

namespace Com.Cognizant.MovieCruiser.DAO
{
    public interface IMovieListDao
    {
        List<MovieList> GetMovieListAdmin();
        List<MovieList> GetMovieListCustomer();
        void ModifyMovieList(MovieList movieList);
        MovieList GetMovieList(long movieListId);
    }
}
