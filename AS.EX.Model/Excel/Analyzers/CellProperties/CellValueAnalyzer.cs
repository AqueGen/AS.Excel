using AS.EX.Model.Consts;
using AS.EX.Model.Excel.EnumTypes;
using System;

namespace AS.EX.Model.Excel.Analyzers.CellProperties
{
    /// <summary>
    /// Analyzer for Value cell property.
    /// </summary>
    public class CellValueAnalyzer
    {
        /// <summary>
        /// Gets the cell value.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException"></exception>
        public static string GetCellValue(CellTypeEnum type, string value)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));

            string newValue = value;

            if (type == CellTypeEnum.Expression || type == CellTypeEnum.Text)
            {
                int expressionSymbolLength = 0;
                if (type == CellTypeEnum.Expression)
                {
                    expressionSymbolLength = CellConst.ExpressionSymbol.Length;
                }
                if (type == CellTypeEnum.Text)
                {
                    expressionSymbolLength = CellConst.TextSymbol.Length;
                }
                newValue = value.Substring(expressionSymbolLength, value.Length - 1);
            }
            return newValue;
        }
    }
}