using AS.EX.Model.Excel.Analyzers.CellProperties;
using AS.EX.Model.Excel.EnumTypes;
using AS.EX.Model.Interfaces;
using System;

namespace AS.EX.Model.Excel.Data.Cells.Properties
{
    public class CellProperties : ICellProperties
    {
        private readonly string _value;

        public CellProperties(string value)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));

            _value = value;
        }

        public bool IsCalculated { get; set; }
        public CellTypeEnum Type { get; set; }
        public string Value { get; set; }

        public void SetupProperties()
        {
            Type = CellTypeAnalyzer.GetCellType(_value);
            Value = CellValueAnalyzer.GetCellValue(Type, _value);
            IsCalculated = CellIsCalculatedAnalyzer.IsCalculated(Type);
        }
    }
}