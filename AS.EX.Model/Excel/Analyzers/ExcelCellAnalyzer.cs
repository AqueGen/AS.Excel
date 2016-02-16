using System.Text.RegularExpressions;

namespace AS.EX.Model.Excel.Analyzers
{
    public class ExcelCellAnalyzer
    {



        /// <summary>
        ///     Determines whether [is cell reference present] [the specified text].
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns></returns>
        public static bool IsCellReferencePresent(string text)
        {
            var regex = new Regex("[A-Z]{1}[0-9]{1}");
            var isMatch = regex.IsMatch(text);
            return isMatch;
        }

        /// <summary>
        ///     Determines whether [is arithmetic operation present] [the specified text].
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns></returns>
        public static bool IsArithmeticOperationPresent(string text)
        {
            var values = text.Split(OperationAnalyzer.GetOperationSymbols());

            var isArithmeticOperationPresent = values.Length > 1;
            return isArithmeticOperationPresent;
        }

    }
}