using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Cognizant.MovieCruiser.Utility
{
    public class DateUtility
    {
        public static DateTime ConvertToDate(string inputDate)
        {
            DateTime dt = DateTime.ParseExact(inputDate, "dd/MM/yyyy", null);
            return dt;
        }
    }
}
