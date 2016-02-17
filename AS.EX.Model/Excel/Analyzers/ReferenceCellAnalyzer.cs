using System;
using System.Text.RegularExpressions;
using AS.EX.Model.Consts;

namespace AS.EX.Model.Excel.Analyzers
{
    public class ReferenceCellAnalyzer
    {
        /// <summary>
        ///     Determines whether [is cell reference present] [the specified text].
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns></returns>
        public static bool IsCellReferencePresent(string text)
        {
            if (String.IsNullOrWhiteSpace(text))
                throw new ArgumentException("Argument is null or whitespace", nameof(text));

            var regex = new Regex("[A-Z]{1}[0-9]{1}");
            var isMatch = regex.IsMatch(text);
            return isMatch;
        }

    }
}