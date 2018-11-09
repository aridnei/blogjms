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
            String result = Regex.Replace(input, @"<[^>]*>", String.Empty);
            MatchCollection matches = Regex.Matches(result, @"[^\b][\w]*[^\b]");

            var words = from match in matches.Cast<Match>()
                        where !string.IsNullOrEmpty(match.Value)
                        select match.Value;

            if (words.Count() >= numberOfWords)
                return string.Join("", words.Take(numberOfWords).Append("..."));
            else
                return string.Join("", words.Take(numberOfWords));
        }
    }
}
