using AS.EX.Model.Consts;
using AS.EX.Model.Excel.EnumTypes;
using System;

namespace AS.EX.Model.Excel.Analyzers.CellProperties
{
    /// <summary>
    /// Analyzer for Type cell property.
    /// </summary>
    public class CellTypeAnalyzer
    {
        /// <summary>
        /// Gets the type of the cell.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException"></exception>
        public static CellTypeEnum GetCellType(string value)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));

            if (string.IsNullOrWhiteSpace(value))
            {
                return CellTypeEnum.Empty;
            }

            const int startIndex = 0;
            const int firstSymbolIndex = 1;

            var firstSymbol = value.Substring(startIndex, firstSymbolIndex);

            if (firstSymbol.Equals(CellConst.ExpressionSymbol))
            {
                return CellTypeEnum.Expression;
            }
            if (firstSymbol.Equals(CellConst.TextSymbol))
            {
                return CellTypeEnum.Text;
            }

            return CellTypeEnum.Number;
        }
    }
}