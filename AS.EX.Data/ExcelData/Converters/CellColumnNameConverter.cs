using System;

namespace AS.EX.Data.ExcelData.Converters
{
    internal static class CellColumnNameConverter
    {
        private const char FirstExcelLetter = 'A';
        private const char LastExcelLetter = 'Z';

        /// <summary>
        ///     Gets the letter.
        /// </summary>
        /// <param name="columnNumber">The column number.</param>
        /// <returns></returns>
        internal static string GetLetterByNumber(int columnNumber)
        {
            string columnName = string.Empty;

            if (columnNumber >= GetAlphabetSize())
            {
                columnName = columnName + GetSecondLetter(columnNumber);
            }

            columnName = columnName + GetFirstLetter(columnNumber);

            return columnName;
        }

        private static int GetAlphabetSize()
        {
            return Convert.ToInt32(LastExcelLetter - FirstExcelLetter);
        }

        private static char GetFirstLetter(int columnNumber)
        {
            int letter = GetLetterIndex(FirstExcelLetter) + columnNumber % GetAlphabetSize();
            return Convert.ToChar(letter);
        }

        private static int GetLetterIndex(char letter)
        {
            return Convert.ToInt32(letter);
        }

        private static char GetSecondLetter(int columnNumber)
        {
            const int startIndex = -1;
            int letter = GetLetterIndex(FirstExcelLetter) + startIndex + columnNumber / GetAlphabetSize();
            return Convert.ToChar(letter);
        }
    }
}