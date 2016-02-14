using AS.EX.Data.ExcelData.EnumTypes;

namespace AS.EX.Data.ExcelData.Converters
{
    public class Converter
    {
        public static string CellNumberToColumnName(int columnNumber)
        {
            return CellColumnNameConverter.GetLetter(columnNumber);
        }


        public static string CastReferenceToValue(CellTable cells, Cell expressionCell)
        {
            return CellValueConverter.CastReferenceToValue(cells, expressionCell);
        }

        public static ArithmeticType ToArithmeticType(char value)
        {
            return (ArithmeticType)value;
        }
    }
}