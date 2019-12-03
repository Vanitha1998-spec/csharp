using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Cognizant.MovieCruiser.Model
{
    public class Favorites
    {
        private List<MovieList> _movieList;
        private double count;

        public Favorites(List<MovieList> _movieList)
        {
            this._movieList = _movieList;
            this.count = 0;
            foreach (MovieList item in this._movieList)
            {
                this.count += (int)item.Budget;
            }
        }

        public List<MovieList> MovieList
        {
            get { return _movieList; }
            set { _movieList = value; }
        }

        public double Count
        {
            get { return count; }
            set { count = value; }
        }

        public override string ToString()
        {
            string str = "";
            if (_movieList != null)
                str += string.Format("\n{0,-10}{1,-20}{2,-15}{3,-15}{4,-20}{5,-15}{6}\n", "Id", "Title", "Budget", "Active", "Date Of Launch", "Genre", "Has Teaser");
            foreach (MovieList item in _movieList)
            {
                string active = (item.Active) ? "Yes" : "No";
                string hasTeaser = (item.HasTeaser) ? "Yes" : "No";
                str += string.Format("{0,-10}{1,-20}{2,-15}{3,-15}{4,-20}{5,-15}{6}\n", item.Id, item.Title, item.Budget.ToString("0.00"), active, item.DateOfLaunch.ToString("dd/MM/yyyy"), item.Genre, hasTeaser);
            }
            str += string.Format("\n{0,-20}{1}", "Movies in Favorites", this.count);
            return str;
        }
    }
}
