using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Cognizant.MovieCruiser.Model;

namespace Com.Cognizant.MovieCruiser.DAO
{
    public class MovieListDaoCollection : IMovieListDao
    {
        List<MovieList> _movieList;
        public MovieListDaoCollection()
        {
            if (_movieList == null)
            {
                _movieList = new List<MovieList>()
                {
                     new MovieList(1, "Lord of the Rings", 1299.87f, true, DateTime.ParseExact("15/11/2019","dd/MM/yyyy", null), "Action", true),
                     new MovieList(2, "Avengers", 5126.89f, true, DateTime.ParseExact("23/12/2019","dd/MM/yyyy", null), "Action", true),
                     new MovieList(3, "Interstellar", 2451.66f, true, DateTime.ParseExact("12/10/2018","dd/MM/yyyy", null), "Science", false),
                     new MovieList(4, "The Hobbit", 1235.32f, true, DateTime.ParseExact("20/03/2020","dd/MM/yyyy", null), "Action", true),
                     new MovieList(5, "Final Destination", 5412.22f, true, DateTime.ParseExact("05/03/2019","dd/MM/yyyy", null), "Horror", true),
                     new MovieList(6, "Batman Begins", 2654.87f, true, DateTime.ParseExact("15/03/2017","dd/MM/yyyy", null), "Action", true),
                };
            }
        }
        public List<MovieList> MovieList
        {
            get
            {
                return _movieList;
            }
            set
            {
                _movieList = value;
            }
        }


        public List<MovieList> GetMovieListAdmin()
        {
            return _movieList;
        }

        public List<MovieList> GetMovieListCustomer()
        {
            List<MovieList> customerList = new List<MovieList>();
            foreach (MovieList item in MovieList)
            {
                if (item.Active && (int)DateTime.Compare(item.DateOfLaunch, DateTime.Now) > 0)
                {
                    customerList.Add(item);
                }
            }
            return customerList;
        }

        public void ModifyMovieList(MovieList movieList)
        {
            var index = _movieList.FindIndex(p => p.Id == movieList.Id);
            _movieList[index] = movieList;
        }

        public MovieList GetMovieList(long movieListId)
        {
            return _movieList.FirstOrDefault(p => p.Id == movieListId);
        }
    }
}
