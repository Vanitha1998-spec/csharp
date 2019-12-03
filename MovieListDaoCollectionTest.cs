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
    class FavoritesListDaoCollectionTest
    {
        static void Main(string[] args)
        {
            string cont = string.Empty;
            do
            {
                Console.WriteLine("1. Add Movie to Favorites:\n2. Remove Favorites Item:\n3. Get All Favorites  Item:\n");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        TestAddFavoritesItem();
                        break;
                    case 2:
                        TestRemoveFavoritesItem();
                        break;
                    case 3:
                        TestGetAllFavoritesItems();
                        break;
                    default:
                        break;
                }
                Console.WriteLine("Do you want to return to the favorite menu list? Type Yes or No");
                cont = Console.ReadLine();
            } while (cont.Equals("yes", StringComparison.InvariantCultureIgnoreCase));
        }
        public static void TestAddFavoritesItem()
        {
            FavoritesDaoCollection favoritestDao = new FavoritesDaoCollection();
            Console.WriteLine("Enter UserId:");
            long userId = long.Parse(Console.ReadLine());
            Favorites favoritesMenuItems = favoritestDao.GetAllFavoritesList(userId);
            Console.WriteLine(favoritesMenuItems);
            Console.WriteLine("Enter Movie Id:");
            long movieItemId = long.Parse(Console.ReadLine());
            favoritestDao.AddFavoriteMovieList(userId, movieItemId);
            favoritesMenuItems = favoritestDao.GetAllFavoritesList(userId);
            Console.WriteLine(favoritesMenuItems);
        }
        public static void TestGetAllFavoritesItems()
        {
            FavoritesDaoCollection favoritesDao = new FavoritesDaoCollection();
            Console.WriteLine("\nEnter User Id");
            try
            {
                Favorites favoritesMovieItems = favoritesDao.GetAllFavoritesList(long.Parse(Console.ReadLine()));
                Console.WriteLine(favoritesMovieItems);
            }
            catch (FavoritesEmptyException fe)
            {
                Console.WriteLine(fe);
            }

        }
        public static void TestRemoveFavoritesItem()
        {
            FavoritesDaoCollection favoritesDao = new FavoritesDaoCollection();
            Console.WriteLine("Enter UserId:");
            long userId = long.Parse(Console.ReadLine());
            Favorites favoritesMovieItems = favoritesDao.GetAllFavoritesList(userId);
            Console.WriteLine(favoritesMovieItems);
            Console.WriteLine("Enter Movie Id:");
            long movieItemId = long.Parse(Console.ReadLine());
            favoritesDao.RemoveFavoriteMovie(userId, movieItemId);
            try
            {
                favoritesMovieItems = favoritesDao.GetAllFavoritesList(userId);
                Console.WriteLine(favoritesMovieItems);
            }
            catch (FavoritesEmptyException fe)
            {
                Console.WriteLine(fe);
            }
        }
    }
}
