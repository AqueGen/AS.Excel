using System;
using System.Text.RegularExpressions;

namespace AS.EX.Model.Excel.Analyzers
{
    /// <summary>
    /// Analyzer for reference cell.
    /// </summary>
    public class ReferenceCellAnalyzer
    {
        /// <summary>
        /// Determines whether [is cell reference present] [the specified text].
        /// </summary>
        /// <param name="cellReferenceName">The text.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentException">Cell reference can not be empty</exception>
        public static bool IsCellReferencePresent(string cellReferenceName)
        {
            if (string.IsNullOrWhiteSpace(cellReferenceName))
                throw new ArgumentException("Cell reference can not be empty");

            var regex = new Regex("[A-Z]{1}[0-9]{1}");
            var isMatch = regex.IsMatch(cellReferenceName);
            return isMatch;
        }
    }
}