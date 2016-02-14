using AS.EX.Data.ExcelData.Analyzers;
using AS.EX.Data.ExcelData.EnumTypes;

namespace AS.EX.Data.ExcelData.Converters
{
    public class CellValueConverter
    {
        public static string CastReferenceToValue(CellTable cells, Cell expressionCell)
        {
            string[] expressionParts = expressionCell.Value.Split(OperationAnalyzer.GetOperationSymbols());

            string value = expressionCell.Value;
            foreach (string part in expressionParts)
            {
                value = GetReferenceValue(cells, expressionCell, value, part);
            }
            return value;
        }

        private static string GetReferenceValue(CellTable cells, Cell expressionCell, string value, string part)
        {
            if (ExcelCellAnalyzer.IsCellReferencePresent(part) && expressionCell.Type != CellType.Error)
            {
                value = ReplaceReferenceToValue(cells, value, part);
            }

            return value;
        }

        private static string ReplaceReferenceToValue(CellTable cells, string value, string part)
        {
            Cell cell = cells.GetCell(part);
            string newValue = value;
            if (cell != null && cell.IsCalculated)
            {
                newValue = value.Replace(part, cell.Value);
            }

            return newValue;
        }
    }
}