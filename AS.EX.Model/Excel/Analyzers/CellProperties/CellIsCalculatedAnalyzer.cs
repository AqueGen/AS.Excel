using AS.EX.Model.Excel.EnumTypes;

namespace AS.EX.Model.Excel.Analyzers.CellProperties
{
    public class CellIsCalculatedAnalyzer
    {
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