using System;
using System.Diagnostics.Contracts;
using System.Text.RegularExpressions;
using AS.EX.Data.ExcelData.Types;

namespace AS.EX.Data.ExcelData.Analyzers
{
    public class ExcelCellAnalyzer
    {
        private const string StartExpression = "=";
        private const string StartText = "'";


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
        public static void SetCellParameters(Cell cell)
        {
            Contract.Requires<ArgumentNullException>(cell != null);

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
            Contract.Requires<ArgumentNullException>(cell != null);
            cell.SetVariables(string.Empty, CellType.Empty, true);
        }

        private static void SetNotEmptyValue(Cell cell, int startIndex, int firstSymbolIndex)
        {
            Contract.Requires<ArgumentNullException>(cell != null);
            var firstSymbol = cell.Value.Substring(startIndex, firstSymbolIndex);

            if (firstSymbol == StartExpression)
            {
                cell.SetVariables(cell.Value.Remove(0, StartExpression.Length), CellType.Expression, true);
            }
            else if (firstSymbol == StartText)
            {
                cell.SetVariables(cell.Value.Remove(0, StartText.Length), CellType.Text, true);
            }
            else
            {
                cell.SetVariables(cell.Value, CellType.Number, true);
                ErrorCellIfNegativeNumber(cell);
            }
        }

        private static void ErrorCellIfNegativeNumber(Cell cell)
        {
            Contract.Requires<ArgumentNullException>(cell != null);

            var value = Convert.ToInt32(cell.Value);
            if (value < 0)
            {
                //cell.SetCellErrorState(ExceptionConstructor.MessageGenerator(ErrorMessage.NegativeNumber, cell));
            }
        }
    }
}