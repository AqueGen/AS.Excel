using System;
using AS.EX.Data.ExcelData.Types;

namespace AS.EX.Data.Extensions
{
    public static class AsExConvert
    {
        public static ArithmeticType ToArithmeticType(char value)
        {
            return (ArithmeticType)value;
        }
    }
}