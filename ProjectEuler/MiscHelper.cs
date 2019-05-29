using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler
{
    public static class MiscHelper
    {
        public static string FromListToString<T>(List<T> list)
        {
            var returnString = new StringBuilder();

            foreach (var e in list)
            {
                returnString.Append($"{e}, ");
            }
            if (returnString.Length > 2)
                returnString.Length -= 2;
            
            return returnString.ToString();
        }
    }
}
