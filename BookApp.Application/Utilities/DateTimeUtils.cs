using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApp.Application.Utilities
{
    public static class DateTimeUtils
    {
        // calculates book return date excluding weekends
        public static DateTime GetBookReturnDate(DateTime issuedDate, int days)
        {

            var sign = Math.Sign(days);
            var unsignedDays = Math.Abs(days);

            for (var i = 0; i < unsignedDays; i++)
            {
                do
                {
                    issuedDate = issuedDate.AddDays(sign);
                }
                while (issuedDate.DayOfWeek == DayOfWeek.Sunday || issuedDate.DayOfWeek == DayOfWeek.Saturday);
            }


            return issuedDate;
        }
    }
}
