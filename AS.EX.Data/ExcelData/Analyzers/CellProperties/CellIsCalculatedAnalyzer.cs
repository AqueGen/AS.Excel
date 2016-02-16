using AS.EX.Data.ExcelData.EnumTypes;

namespace AS.EX.Data.ExcelData.Analyzers.CellProperties
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