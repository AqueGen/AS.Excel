using System;
using System.Diagnostics.Contracts;
using AS.EX.Data.ExcelData.EnumTypes;

namespace AS.EX.Data.ExcelData.Calculates
{
    /// <summary>
    ///     Class for operation with cells.
    /// </summary>
    public static class CellArithmeticCalculation
    {
        /// <summary>
        ///     Calculates the number.
        /// </summary>
        /// <param name="value1">The value1.</param>
        /// <param name="type">The type.</param>
        /// <param name="value2">The value2.</param>
        /// <returns></returns>
        public static int CalculateNumber(int value1, ArithmeticType type, int value2)
        {
            switch (type)
            {
                case ArithmeticType.Add:
                    return value1 + value2;
                case ArithmeticType.Subtract:
                    return value1 - value2;
                case ArithmeticType.Multiply:
                    return value1 * value2;
                case ArithmeticType.Divide:
                    return value1 / value2;
                default:
                    throw new ArgumentException("Udentityfie operation symbol");
            }
        }
    }
}