using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2.Shared.Utilities
{
    public class Formatter
    {
        public static DateTime FormatToDateTime(string dateStringLocal)
        {
            DateTime parsedDate = DateTime.ParseExact(dateStringLocal, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            return parsedDate;
        }
    }
}
