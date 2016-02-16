using System;
using AS.EX.Model.Excel.EnumTypes;

namespace AS.EX.Model.Excel.Calculates
{
    /// <summary>
    ///     Class for operation with cells.
    /// </summary>
    public static class CellArithmeticCalculation
    {

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