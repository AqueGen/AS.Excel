using System;
using AS.EX.Model.Consts;
using AS.EX.Model.Excel.EnumTypes;

namespace AS.EX.Model.Excel.Analyzers.CellProperties
{
    public class CellValueAnalyzer
    {
        public static string GetCellValue(CellTypeEnum type, string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Argument is null or whitespace", nameof(value));

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