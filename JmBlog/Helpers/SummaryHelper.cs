using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace JmBlog.Helpers
{
    public static class SummaryHelper
    {
        public static string GetWords(string input, int numberOfWords)
        {
            MatchCollection matches = Regex.Matches(input, @"\b[\w']*\b");

            var words = from match in matches.Cast<Match>()
                        where !string.IsNullOrEmpty(match.Value)
                        select match.Value;

            return string.Join(" ", words.Take(numberOfWords));
        }
    }
}
