namespace AS.EX.Converters.Converters
{
    public static class Converter
    {
        public static string Number2ColumnName(int columnNumber)
        {
            return Number2ColumnNameConverter.GetLetter(columnNumber);
        }
    }
}