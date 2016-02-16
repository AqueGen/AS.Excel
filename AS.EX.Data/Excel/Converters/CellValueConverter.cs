using AS.EX.Model.Excel.Analyzers;
using AS.EX.Model.Excel.EnumTypes;

namespace AS.EX.Model.Excel.Converters
{
    public class CellValueConverter
    {
        public static string ConvertCellReferenceToValue(CellTable table, Cell expressionCell)
        {
            string[] expressionParts = expressionCell.CellValue.Split(OperationAnalyzer.GetOperationSymbols());

            string value = expressionCell.CellValue;
            foreach (string part in expressionParts)
            {
                value = GetReferenceValue(table, expressionCell, value, part);
            }
            return value;
        }

        private static string GetReferenceValue(CellTable table, Cell expressionCell, string value, string part)
        {
            if (ExcelCellAnalyzer.IsCellReferencePresent(part) && expressionCell.CellType != CellTypeEnum.Error)
            {
                value = ReplaceReferenceToValue(table, value, part);
            }

            return value;
        }

        private static string ReplaceReferenceToValue(CellTable table, string value, string part)
        {
            Cell cell = table.GetCell(part);
            string newValue = value;
            if (cell?.CellValue != null && cell.IsCalculated)
            {
                newValue = value.Replace(part, cell.CellValue);
            }

            return newValue;
        }
    }
}