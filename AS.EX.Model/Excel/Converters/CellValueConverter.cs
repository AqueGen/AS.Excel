using AS.EX.Model.Consts;
using AS.EX.Model.Excel.Analyzers;
using AS.EX.Model.Excel.Data;
using AS.EX.Model.Excel.Data.Cells;
using AS.EX.Model.Excel.EnumTypes;
using AS.EX.Model.Interfaces;

namespace AS.EX.Model.Excel.Converters
{
    public class CellValueConverter
    {
        public static string ConvertCellReferenceToValue(CellTable table, ICell cell)
        {
            string value = cell.Value;
            string[] parts = cell.Value.Split(CellConst.OperationSymbols);

            foreach (string part in parts)
            {
                if (ReferenceCellAnalyzer.IsCellReferencePresent(part) && cell.Type != CellTypeEnum.Error)
                {
                    value = ReplaceReferenceToValue(table, value, part);
                }
            }
            return value;
        }

        private static string ReplaceReferenceToValue(CellTable table, string value, string part)
        {
            ICell cell = table.GetCell(part);
            string newValue = value;
            if (cell?.Value != null && cell.IsCalculated)
            {
                newValue = value.Replace(part, cell.Value);
            }

            return newValue;
        }
    }
}