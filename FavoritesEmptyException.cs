using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Cognizant.MovieCruiser.DAO
{
    public class FavoritesEmptyException : ApplicationException
    {
        string s;
        public FavoritesEmptyException(string str)
        {
            s = str;
        }
        public override string ToString()
        {
            return s;
        }
    }
}
