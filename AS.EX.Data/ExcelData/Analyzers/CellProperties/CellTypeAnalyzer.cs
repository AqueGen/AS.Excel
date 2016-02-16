using AS.EX.Data.Consts;
using AS.EX.Data.ExcelData.EnumTypes;

namespace AS.EX.Data.ExcelData.Analyzers.CellProperties
{
    public class CellTypeAnalyzer
    {


        public static CellTypeEnum GetCellType(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
               return CellTypeEnum.Empty;
            }

            CellTypeEnum typeEnum = GetValueType(value);
            return typeEnum;
        }


        private static CellTypeEnum GetValueType(string value)
        {
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