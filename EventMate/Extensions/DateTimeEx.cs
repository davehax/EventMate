using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventMate.Extensions
{
    public static class DateTimeEx
    {
        /// <summary>
        /// Expresses a DateTime as a human-readable string in the format
        /// [day] [date with suffix] [month] [year]
        /// e.g. Friday 17th June 2016
        /// See https://stackoverflow.com/a/37881429 for more information
        /// </summary>
        /// <param name="date"></param>
        /// <returns>Expresses a DateTime as a human-readable string</returns>
        public static string HumanisedDate(this DateTime date)
        {
            string ordinal;

            switch (date.Day)
            {
                case 1:
                case 21:
                case 31:
                    ordinal = "st";
                    break;
                case 2:
                case 22:
                    ordinal = "nd";
                    break;
                case 3:
                case 23:
                    ordinal = "rd";
                    break;
                default:
                    ordinal = "th";
                    break;
            }

            return string.Format("{0:dddd d}{1} {0:MMMM yyyy}", date, ordinal);
        }
    }
}