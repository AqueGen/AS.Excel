using AS.EX.Model.Excel.Analyzers.CellProperties;
using AS.EX.Model.Excel.EnumTypes;

namespace AS.EX.Model.Excel
{
    public class CellProperties
    {
        private readonly string _value;

        public CellTypeEnum CellType {get; set; }

        public string CellValue { get; set; }
        public bool IsCalculated { get; set; }

        public CellProperties(string value)
        {
            _value = value;
            SetupProperties();
        }

        private void SetupProperties()
        {
            SetupCellType();
            SetupValue();
            SetupIsCalculated();
        }

        private void SetupIsCalculated()
        {
            IsCalculated = CellIsCalculatedAnalyzer.IsCalculated(CellType);
        }

        private void SetupCellType()
        {
            CellType = CellTypeAnalyzer.GetCellType(_value);
        }

        private void SetupValue()
        {
            CellValue = CellValueAnalyzer.GetCellValue(CellType, _value);
        }


    }
}