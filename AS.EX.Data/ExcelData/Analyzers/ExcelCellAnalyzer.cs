using System;
using System.Text.RegularExpressions;
using AS.EX.Data.ExcelData.EnumTypes;

namespace AS.EX.Data.ExcelData.Analyzers
{
    public class ExcelCellAnalyzer
    {
        private const string ExpressionSymbol = "=";
        private const string TextSumbol = "'";


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


        /// <summary>
        ///     Setups the cell parameters.
        /// </summary>
        /// <param name="cell">The cell.</param>
        public static void SetParametersForCell(Cell cell)
        {
            const int startIndex = 0;
            const int firstSymbolIndex = 1;

            if (string.IsNullOrWhiteSpace(cell.Value))
            {
                SetEmptyValue(cell);
            }
            else
            {
                SetNotEmptyValue(cell, startIndex, firstSymbolIndex);
            }
        }

        private static void SetEmptyValue(Cell cell)
        {
            cell.SetVariables(string.Empty, CellType.Empty, true);
        }

        private static void SetNotEmptyValue(Cell cell, int startIndex, int firstSymbolIndex)
        {
            var firstSymbol = cell.Value.Substring(startIndex, firstSymbolIndex);

            if (firstSymbol.Equals(ExpressionSymbol))
            {
                cell.SetVariables(cell.Value.Remove(0, ExpressionSymbol.Length), CellType.Expression, true);
            }
            else if (firstSymbol.Equals(TextSumbol))
            {
                cell.SetVariables(cell.Value.Remove(0, TextSumbol.Length), CellType.Text, true);
            }
            else
            {
                cell.SetVariables(cell.Value, CellType.Number, true);
                ErrorCellIfNegativeNumber(cell);
            }
        }

        private static void ErrorCellIfNegativeNumber(Cell cell)
        {
            var value = Convert.ToInt32(cell.Value);
            if (value < 0)
            {
                cell.SetCellErrorState("Negative number");
            }
        }
    }
}