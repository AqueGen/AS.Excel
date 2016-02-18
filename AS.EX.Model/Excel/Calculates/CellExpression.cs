using AS.EX.Model.Consts;
using AS.EX.Model.Excel.Converters;
using AS.EX.Model.Excel.EnumTypes;
using AS.EX.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AS.EX.Model.Excel.Calculates
{
    /// <summary>
    /// Class for work with expression cell type.
    /// </summary>
    public class CellExpression
    {
        /// <summary>
        /// Calculates the expression.
        /// </summary>
        /// <param name="cell">The cell.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException"></exception>
        public static string Calculate(ICell cell)
        {
            if (cell == null) throw new ArgumentNullException(nameof(cell));

            int[] numbers;
            char[] operations;
            SplitExpression(cell, out numbers, out operations);

            const int differentLength = 1;

            var totalValue = Convert.ToInt32(numbers[0]);
            for (var i = 1; i <= operations.Length; i++)
            {
                ArithmeticTypeEnum arithmeticTypeEnum = Converter.ToArithmeticType(operations[i - differentLength]);
                var nextNumber = Convert.ToInt32(numbers[i]);
                totalValue = CellArithmeticCalculation.CalculateNumber(totalValue, arithmeticTypeEnum, nextNumber);
            }
            return totalValue.ToString();
        }

        /// <summary>
        /// Splits the expression.
        /// </summary>
        /// <param name="cell">The cell.</param>
        /// <param name="numbers">The numbers.</param>
        /// <param name="operations">The operations.</param>
        /// <exception cref="System.ArgumentNullException"></exception>
        public static void SplitExpression(ICell cell, out int[] numbers, out char[] operations)
        {
            if (cell == null) throw new ArgumentNullException(nameof(cell));

            var nums = new List<int>();
            var opers = new List<char>();

            int num = 0;

            var expressionValue = new ExpressionValue(cell.Value.ToCharArray());

            for (int i = 0; i < expressionValue.Chars.Length; i++)
            {
                expressionValue.Index = i;
                if (CellConst.OperationSymbols.Contains(expressionValue.Chars[i]))
                {
                    Operation(nums, opers, ref num, expressionValue);
                }
                else
                {
                    Number(expressionValue);
                }
            }

            num = Convert.ToInt32(expressionValue.Value);
            nums.Add(num);

            numbers = nums.ToArray();
            operations = opers.ToArray();
        }

        private static void Number(ExpressionValue expressionValue)
        {
            if (expressionValue == null) throw new ArgumentNullException(nameof(expressionValue));

            if (CellConst.AllNumbers.Contains(expressionValue.Chars[expressionValue.Index]))
            {
                expressionValue.Value += expressionValue.Chars[expressionValue.Index];
                expressionValue.IsNextShouldBeNumber = false;
            }
        }

        private static void Operation(List<int> nums, List<char> opers, ref int num,
            ExpressionValue expressionValue)
        {
            if (nums == null) throw new ArgumentNullException(nameof(nums));
            if (expressionValue == null) throw new ArgumentNullException(nameof(expressionValue));

            if (expressionValue.Index == CellConst.ZeroIndex)
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
            public ExpressionValue(char[] chars)
            {
                Chars = chars;
            }

            public char[] Chars { get; }
            public int Index { get; set; }
            public bool IsNextShouldBeNumber { get; set; }
            public string Value { get; set; }
        }
    }
}