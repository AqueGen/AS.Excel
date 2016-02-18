using AS.EX.Model.Excel.EnumTypes;

namespace AS.EX.Model.Excel.Analyzers.CellProperties
{
    /// <summary>
    /// Analyzer for IsCalculated cell property.
    /// </summary>
    public class CellIsCalculatedAnalyzer
    {
        /// <summary>
        /// Determines whether the specified type is calculated.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        public static bool IsCalculated(CellTypeEnum type)
        {
            if (type == CellTypeEnum.Expression)
            {
                return false;
            }
            return true;
        }
    }
}