using AS.EX.Model.Excel.EnumTypes;
using System;

namespace AS.EX.Model.Excel.Calculates
{
    /// <summary>
    /// Class for arithmetic operation with number type cells.
    /// </summary>
    public static class CellArithmeticCalculation
    {
        /// <summary>
        /// Calculates the number.
        /// </summary>
        /// <param name="value1">The value1.</param>
        /// <param name="typeEnum">The type enum.</param>
        /// <param name="value2">The value2.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentException">Unknown operation symbol</exception>
        public static int CalculateNumber(int value1, ArithmeticTypeEnum typeEnum, int value2)
        {
            switch (typeEnum)
            {
                case ArithmeticTypeEnum.Add:
                    return value1 + value2;

                case ArithmeticTypeEnum.Subtract:
                    return value1 - value2;

                case ArithmeticTypeEnum.Multiply:
                    return value1 * value2;

                case ArithmeticTypeEnum.Divide:
                    return value1 / value2;

                default:
                    throw new ArgumentException("Unknown operation symbol");
            }
        }
    }
}