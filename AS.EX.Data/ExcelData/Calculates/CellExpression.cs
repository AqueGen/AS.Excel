using System;
using System.Collections.Generic;
using System.Linq;
using AS.EX.Data.ExcelData.Analyzers;
using AS.EX.Data.ExcelData.Converters;
using AS.EX.Data.ExcelData.EnumTypes;

namespace AS.EX.Data.ExcelData.Calculates
{
    /// <summary>
    ///     Class for work with expression cell type.
    /// </summary>
    public class CellExpression
    {
        private const int ZeroIndex = 0;


        private static readonly char[] AllNumbers = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

        /// <summary>
        ///     Calculates the expression.
        /// </summary>
        /// <param name="cell">The cell.</param>
        /// <returns></returns>
        public static string Calculate(Cell cell)
        {
            int[] numbers;
            char[] operations;
            SplitExpression(cell, out numbers, out operations);

            const int differentLength = 1;

            var totalValue = Convert.ToInt32(numbers[0]);
            for (var i = 1; i <= operations.Length; i++)
            {
                ArithmeticType arithmeticType = Converter.ToArithmeticType(operations[i - differentLength]);
                var nextNumber = Convert.ToInt32(numbers[i]);
                totalValue = CellArithmeticCalculation.CalculateNumber(totalValue, arithmeticType, nextNumber);
            }
            return totalValue.ToString();
        }

        /// <summary>
        ///     Splits the expression.
        /// </summary>
        /// <param name="cell">The cell.</param>
        /// <param name="numbers">The numbers.</param>
        /// <param name="operations">The operations.</param>
        public static void SplitExpression(Cell cell, out int[] numbers, out char[] operations)
        {
            var nums = new List<int>();
            var opers = new List<char>();

            var num = 0;

            var expressionValue = new ExpressionValue
            {
                Value = string.Empty,
                IsNextShouldBeNumber = false,
                Chars = cell.Value.ToCharArray()
            };


            for (var i = 0; i < expressionValue.Chars.Length; i++)
            {
                expressionValue.Index = i;
                if (OperationAnalyzer.GetOperationSymbols().Contains(expressionValue.Chars[i]))
                {
                    CharIsOperationSymbol(nums, opers, ref num, expressionValue);
                }
                else
                {
                    CharIsNumber(expressionValue);
                }
            }

            num = Convert.ToInt32(expressionValue.Value);
            nums.Add(num);

            numbers = nums.ToArray();
            operations = opers.ToArray();
        }

        private static void CharIsNumber(ExpressionValue expressionValue)
        {
            if (AllNumbers.Contains(expressionValue.Chars[expressionValue.Index]))
            {
                expressionValue.Value += expressionValue.Chars[expressionValue.Index];
                expressionValue.IsNextShouldBeNumber = false;
            }
        }


        private static void CharIsOperationSymbol(List<int> nums, List<char> opers, ref int num,
            ExpressionValue expressionValue)
        {
            if (expressionValue.Index == ZeroIndex)
            {
                expressionValue.Value = expressionValue.Chars[expressionValue.Index].ToString();
            }
            else
            {
                if (!expressionValue.IsNextShouldBeNumber)
                {
                    num = Convert.ToInt32(expressionValue.Value);
                    nums.Add(num);
                    opers.Add(expressionValue.Chars[expressionValue.Index]);
                    expressionValue.IsNextShouldBeNumber = true;
                    expressionValue.Value = string.Empty;
                }
                else
                {
                    expressionValue.Value += expressionValue.Chars[expressionValue.Index];
                }
            }
        }

        private class ExpressionValue
        {
            public char[] Chars { get; set; }
            public string Value { get; set; }
            public bool IsNextShouldBeNumber { get; set; }
            public int Index { get; set; }
        }
    }
}