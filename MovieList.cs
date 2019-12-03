using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Cognizant.MovieCruiser.Model
{
    public class MovieList
    {
        private long _id;
        private string _title;
        private float _budget;
        private bool _active;
        private DateTime _dateOfLaunch;
        private string _genre;
        private bool _hasTeaser;

        public MovieList()
        {

        }

        public MovieList(long _id, string _title, float _budget, bool _active, DateTime _dateOfLaunch, string _genre, bool _hasTeaser)
        {
            this._id = _id;
            this._title = _title;
            this._budget = _budget;
            this._active = _active;
            this._dateOfLaunch = _dateOfLaunch;
            this._genre = _genre;
            this._hasTeaser = _hasTeaser;
        }

        public long Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        public float Budget
        {
            get { return _budget; }
            set { _budget = value; }
        }

        public bool Active
        {
            get { return _active; }
            set { _active = value; }
        }

        public DateTime DateOfLaunch
        {
            get { return _dateOfLaunch; }
            set { _dateOfLaunch = value; }
        }

        public string Genre
        {
            get { return _genre; }
            set { _genre = value; }
        }

        public bool HasTeaser
        {
            get { return _hasTeaser; }
            set { _hasTeaser = value; }
        }

        public override string ToString()
        {
            string active = (_active) ? "Yes" : "No";
            string hasTeaser = (_hasTeaser) ? "Yes" : "No";
            return string.Format("\n{0,-20}{1,-25}{2,-20}{3,-20}{4,-20}{5,-20}{6}", _id, _title, _budget.ToString("0.00"), active, _dateOfLaunch.ToString("dd/MM/yyyy"), _genre, hasTeaser);
        }
        public override bool Equals(object obj)
        {
            MovieList ob = (MovieList)obj;
            if (ob.Id == this._id)
                return true;
            return false;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
