using System;
using AS.EX.Data.ExcelData.Converters;
using AS.EX.Data.ExcelData.EnumTypes;

namespace AS.EX.Data.ExcelData.Analyzers
{
    public class OperationAnalyzer
    {
        /// <summary>
        ///     Gets the enum element by value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static ArithmeticTypeEnum ValueToArithmeticType(char value)
        {
            return Converter.ToArithmeticType(value);
        }

        /// <summary>
        ///     Gets the operation symbols.
        /// </summary>
        /// <returns></returns>
        public static char[] GetOperationSymbols()
        {
            Array operations = Enum.GetValues(typeof(ArithmeticTypeEnum));

            char[] arithmeticOperations = new char[operations.Length];
            int arithmeticOperationIndex = 0;
            foreach (ArithmeticTypeEnum operation in operations)
            {
                arithmeticOperations[arithmeticOperationIndex] = (char)operation;
                arithmeticOperationIndex++;
            }
            return arithmeticOperations;
        }
        
    }
}