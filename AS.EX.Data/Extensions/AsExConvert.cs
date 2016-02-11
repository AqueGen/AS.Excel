using System;
using AS.EX.Data.ExcelData;
using AS.EX.Data.ExcelData.Analyzers;
using AS.EX.Data.ExcelData.Types;

namespace AS.EX.Data.Extensions
{
    public static class AsExConvert
    {
        public static ArithmeticType ToArithmeticType(char value)
        {
            return (ArithmeticType)value;
        }

        public static string CastReferenceToValue(CellTable cells, Cell expressionCell)
        {
            var expressionParts = expressionCell.Value.Split(OperationAnalyzer.GetOperationSymbols());

            var value = expressionCell.Value;
            foreach (var part in expressionParts)
            {
                if (ExcelCellAnalyzer.IsCellReferencePresent(part) && expressionCell.Type != CellType.Error)
                {
                    var cell = cells.GetCell(part);
                    if (cell != null && cell.IsCalculated)
                    {
                        value = value.Replace(part, cell.Value);
                    }
                }
            }
            return value;
        }

    }
}