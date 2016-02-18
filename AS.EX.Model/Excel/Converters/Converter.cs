using AS.EX.Model.Excel.EnumTypes;
using AS.EX.Model.Interfaces;

namespace AS.EX.Model.Excel.Converters
{
    /// <summary>
    /// Converter class.
    /// </summary>
    public static class Converter
    {
        /// <summary>
        /// Convert cell number to column name.
        /// </summary>
        /// <param name="columnNumber">The column number.</param>
        /// <returns></returns>
        public static string CellNumberToColumnName(int columnNumber)
        {
            return CellColumnNameConverter.GetLetterByNumber(columnNumber);
        }

        /// <summary>
        /// Converts the cell reference to value.
        /// </summary>
        /// <param name="table">The table.</param>
        /// <param name="cell">The cell.</param>
        public static void ConvertCellReferenceToValue(ITable table, ICell cell)
        {
            CellValueConverter.ConvertCellReferenceToValue(table, cell);
        }

        /// <summary>
        /// Convert value to arithmetic type.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static ArithmeticTypeEnum ToArithmeticType(char value)
        {
            return (ArithmeticTypeEnum)value;
        }
    }
}