using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Cognizant.MovieCruiser.DAO;
using Com.Cognizant.MovieCruiser.Model;
using Com.Cognizant.MovieCruiser.Utility;

namespace Com.Cognizant.MovieCruiser.Test
{
    class MovieListDaoCollectionTest
    {
        static void Main(string[] args)
        {
            string Cont = string.Empty;
            do
            {
                Console.WriteLine("Movie Cruiser \n1. Get Movie Item List Admin:\n2. Get Movie Item List Customer:\n3. Modify Movie:\n4. Get Movies:\nEnter the Menu number to view the Corresponding List");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        TestGetMovieListAdmin();
                        break;
                    case 2:
                        TestGetMovieListCustomer();
                        break;
                    case 3:
                        TestModifyMovie();
                        break;
                    case 4:
                        TestGetMovie();
                        break;
                    default:
                        break;
                }
                Console.WriteLine("\nDo you want to go back to Movie menu? Type Yes Or No");
                Cont = Console.ReadLine();
            } while (Cont.Equals("Yes", StringComparison.InvariantCultureIgnoreCase));
            Console.ReadKey();
        }
        public static void TestGetMovieListAdmin()
        {
            MovieListDaoCollection movieListDao = new MovieListDaoCollection();
            List<MovieList> movieList = movieListDao.GetMovieListAdmin();
            Console.WriteLine("\n{0,-20}{1,-25}{2,-20}{3,-20}{4,-20}{5,-20}{6}", "Id", "Title", "Budget", "Active", "Date Of Launch", "Genre", "Has Teaser");
            foreach (MovieList item in movieList)
            {
                Console.WriteLine(item);
            }
        }
        public static void TestGetMovieListCustomer()
        {
            MovieListDaoCollection movieListDao = new MovieListDaoCollection();
            List<MovieList> movieList = movieListDao.GetMovieListCustomer();
            Console.WriteLine("\n{0,-20}{1,-25}{2,-20}{3,-20}{4,-20}{5,-20}{6}", "Id", "Title", "Budget", "Active", "Date Of Launch", "Genre", "Has Teaser");
            foreach (MovieList item in movieList)
            {
                Console.WriteLine(item);
            }
        }
        public static void TestModifyMovie()
        {
            MovieListDaoCollection movieListDao = new MovieListDaoCollection();

            List<MovieList> movieList = movieListDao.GetMovieListAdmin();
            Console.WriteLine("After making Modification:\n{0,-20}{1,-25}{2,-20}{3,-20}{4,-20}{5,-20}{6}", "Id", "Title", "Budget", "Active", "Date Of Launch", "Genre", "Has Teaser");
            foreach (MovieList item in movieList)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Enter Movie Id:");
            long id = long.Parse(Console.ReadLine());

            Console.WriteLine("Enter Movie Title:");
            string title = Console.ReadLine();

            Console.WriteLine("Enter Movie budget:");
            float budget = float.Parse(Console.ReadLine());

            Console.WriteLine("Enter Movie Active Status (Yes/No):");
            string active = Console.ReadLine();
            bool activeStatus;
            if (active.Equals("yes", StringComparison.InvariantCultureIgnoreCase))
                activeStatus = true;
            else
                activeStatus = false;

            Console.WriteLine("Enter Movie Date of Launch(DD/MM/YYYY):");
            DateTime dateOfLaunch = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);

            Console.WriteLine("Enter Movie Genre:");
            string Genre = Console.ReadLine();

            Console.WriteLine("Does it have Teaser (Yes/No):");
            string hasteaser = Console.ReadLine();
            bool freeDeliveryStatus;
            if (hasteaser.Equals("yes", StringComparison.InvariantCultureIgnoreCase))
                freeDeliveryStatus = true;
            else
                freeDeliveryStatus = false;

            movieListDao.ModifyMovieList(new MovieList(id, title, budget, activeStatus, dateOfLaunch, Genre, freeDeliveryStatus));

            movieList = movieListDao.GetMovieListAdmin();
            Console.WriteLine("Before making Modification:\n{0,-20}{1,-25}{2,-20}{3,-20}{4,-20}{5,-20}{6}", "Id", "Name", "Price", "Active", "Date Of Launch", "Category", "Free Delivery");
            foreach (MovieList item in movieList)
            {
                Console.WriteLine(item);
            };
        }
        public static void TestGetMovie()
        {
            Console.WriteLine("Enter Movie  Id:");
            long id = long.Parse(Console.ReadLine());
            MovieListDaoCollection movieListDao = new MovieListDaoCollection();
            Console.WriteLine(movieListDao.GetMovieList(id));
        }
    }
}
