using AS.EX.Model.Excel.Analyzers;
using AS.EX.Model.Excel.Data;
using AS.EX.Model.Excel.EnumTypes;

namespace AS.EX.Model.Excel.Converters
{
    public class CellValueConverter
    {
        public static string ConvertCellReferenceToValue(CellTable table, Cell cell)
        {
            string value = cell.CellValue;
            string[] parts = cell.CellValue.Split(OperationAnalyzer.GetOperationSymbols());

            foreach (string part in parts)
            {
                if (ExcelCellAnalyzer.IsCellReferencePresent(part) && cell.CellType != CellTypeEnum.Error)
                {
                    value = ReplaceReferenceToValue(table, value, part);
                }
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