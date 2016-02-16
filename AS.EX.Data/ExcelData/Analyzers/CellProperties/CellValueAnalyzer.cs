using AS.EX.Data.Consts;
using AS.EX.Data.ExcelData.EnumTypes;

namespace AS.EX.Data.ExcelData.Analyzers.CellProperties
{
    public class CellValueAnalyzer
    {
        public static string GetCellValue(CellTypeEnum type, string value)
        {

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