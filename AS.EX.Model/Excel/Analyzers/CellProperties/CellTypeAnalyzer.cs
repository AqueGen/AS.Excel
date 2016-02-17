using System;
using AS.EX.Model.Consts;
using AS.EX.Model.Excel.EnumTypes;

namespace AS.EX.Model.Excel.Analyzers.CellProperties
{
    public class CellTypeAnalyzer
    {
        public static CellTypeEnum GetCellType(string value)
        {
            if (String.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Argument is null or whitespace", nameof(value));

            if (string.IsNullOrWhiteSpace(value))
            {
               return CellTypeEnum.Empty;
            }

            CellTypeEnum typeEnum = GetValueType(value);
            return typeEnum;
        }


        private static CellTypeEnum GetValueType(string value)
        {
            if (String.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Argument is null or whitespace", nameof(value));

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