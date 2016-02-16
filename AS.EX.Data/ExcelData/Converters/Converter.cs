using System.Collections.Generic;
using AS.EX.Data.ExcelData.EnumTypes;

namespace AS.EX.Data.ExcelData.Converters
{
    public class Converter
    {
        public static string CellNumberToColumnName(int columnNumber)
        {
            return CellColumnNameConverter.GetLetterByNumber(columnNumber);
        }


        public static string ConvertCellReferenceToValue(CellTable table, Cell expressionCell)
        {
            return CellValueConverter.ConvertCellReferenceToValue(table, expressionCell);
        }

        public static ArithmeticTypeEnum ToArithmeticType(char value)
        {
            return (ArithmeticTypeEnum)value;
        }
    }
}