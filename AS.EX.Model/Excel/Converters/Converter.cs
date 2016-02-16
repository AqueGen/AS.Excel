using AS.EX.Model.Excel.EnumTypes;

namespace AS.EX.Model.Excel.Converters
{
    public class Converter
    {
        public static string CellNumberToColumnName(int columnNumber)
        {
            return CellColumnNameConverter.GetLetterByNumber(columnNumber);
        }


        public static string ConvertCellReferenceToValue(CellTable table, Cell cell)
        {
            return CellValueConverter.ConvertCellReferenceToValue(table, cell);
        }

        public static ArithmeticTypeEnum ToArithmeticType(char value)
        {
            return (ArithmeticTypeEnum)value;
        }
    }
}