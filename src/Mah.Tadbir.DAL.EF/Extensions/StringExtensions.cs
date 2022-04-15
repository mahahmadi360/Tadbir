using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Mah.Tadbir.DAL.EF.Extensions
{
    internal static class StringExtensions
    {
        internal static string ToUnderScore(this string input)
        {
            var output = Regex.Replace(input, "([A-Z])", "_$0",
               System.Text.RegularExpressions.RegexOptions.Compiled).ToUpper();
            return output.StartsWith("_") ? output.Substring(1) : output;
        }
    }
}
