using System;
using AS.EX.Model.Consts;
using AS.EX.Model.Excel.EnumTypes;

namespace AS.EX.Model.Excel.Analyzers.CellProperties
{
    public class CellTypeAnalyzer
    {
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