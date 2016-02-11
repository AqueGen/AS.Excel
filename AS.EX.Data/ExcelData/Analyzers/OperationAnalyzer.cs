using System;
using AS.EX.Data.ExcelData.Types;
using AS.EX.Data.Extensions;

namespace AS.EX.Data.ExcelData.Analyzers
{
    public class OperationAnalyzer
    {
        /// <summary>
        ///     Gets the enum element by value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static ArithmeticType Value2ArithmeticType(char value)
        {
            return AsExConvert.ToArithmeticType(value);
        }

        /// <summary>
        ///     Gets the operation symbols.
        /// </summary>
        /// <returns></returns>
        public static char[] GetOperationSymbols()
        {
            var operations = Enum.GetValues(typeof(ArithmeticType));

            var arithmeticOperations = new char[operations.Length];
            var arithmeticOperationIndex = 0;
            foreach (ArithmeticType operation in operations)
            {
                arithmeticOperations[arithmeticOperationIndex] = (char)operation;
                arithmeticOperationIndex++;
            }
            return arithmeticOperations;
        }
        
    }
}